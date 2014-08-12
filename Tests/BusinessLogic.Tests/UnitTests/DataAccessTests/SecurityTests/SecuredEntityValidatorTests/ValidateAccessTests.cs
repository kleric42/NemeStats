﻿using BusinessLogic.DataAccess;
using BusinessLogic.DataAccess.Security;
using BusinessLogic.Models;
using BusinessLogic.Models.User;
using NUnit.Framework;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Tests.UnitTests.DataAccessTests.SecurityTests.SecuredEntityValidatorTests
{
    [TestFixture]
    public class ValidateAccessTests
    {
        protected SecuredEntityValidatorImpl<SecuredEntityWithTechnicalKey> securedEntityValidatorForSecuredEntity;
        protected SecuredEntityValidatorImpl<object> securedEntityValidatorForEntityThatIsNotSecured;
        protected SecuredEntityWithTechnicalKey securedEntity;
        protected ApplicationUser currentUser;
        protected int securedEntityGamingGroupId = 1;
        protected int securedEntityId = 9;

        [SetUp]
        public void SetUp()
        {
            securedEntityValidatorForSecuredEntity = new SecuredEntityValidatorImpl<SecuredEntityWithTechnicalKey>();
            securedEntityValidatorForEntityThatIsNotSecured = new SecuredEntityValidatorImpl<object>();
            securedEntity = MockRepository.GenerateMock<SecuredEntityWithTechnicalKey>();
            currentUser = new ApplicationUser();

            securedEntity.Expect(mock => mock.GamingGroupId)
                 .Repeat.Any()
                 .Return(securedEntityGamingGroupId);
        }

        [Test]
        public void ItThrowsAnUnauthorizedAccessExceptionIfTheGamingGroupIdsDoNotMatch()
        {
            currentUser.CurrentGamingGroupId = 999999;
            Type stringType = typeof(string);

            Exception exception = Assert.Throws<UnauthorizedAccessException>(
                () => securedEntityValidatorForSecuredEntity.ValidateAccess(securedEntity, currentUser, stringType));

            string message = string.Format(
                "XXX",//SecuredEntityValidatorImpl<SecuredEntityWithTechnicalKey>.EXCEPTION_MESSAGE_USER_DOES_NOT_HAVE_ACCESS_TO_ENTITY,
                currentUser.Id,
                stringType
                );
            Assert.AreEqual(message, exception.Message);
        }

        [Test]
        public void ItDoesNotThrowAnExceptionIfTheEntityIsNotASecuredEntityWithTechnicalKey()
        {
            securedEntityValidatorForEntityThatIsNotSecured.ValidateAccess(
                "some object that doesnt extend SecuredEntityWithTechnicalKey", 
                currentUser, 
                typeof(string));
        }

        [Test]
        public void ItDoesNotThrowAnExceptionIfTheUserHasTheGamingGroupOfTheSecuredEntity()
        {
            currentUser.CurrentGamingGroupId = securedEntity.GamingGroupId;

            securedEntityValidatorForEntityThatIsNotSecured.ValidateAccess(
                securedEntity,
                currentUser,
                typeof(string));
        }

        [Test]
        public void ItThrowsAnArgumentNullExceptionIfTheCurrentUserIsNullAndTheEntityIsSecured()
        {
            Exception exception = Assert.Throws<ArgumentNullException>(
                () => securedEntityValidatorForSecuredEntity.ValidateAccess(securedEntity, null, typeof(string)));
        }

        [Test]
        public void ItThrowsAnArgumentExceptionIfTheGamingGroupIdIsNullAndTheEntityIsSecured()
        {
            Exception exception = Assert.Throws<ArgumentException>(
                () => securedEntityValidatorForSecuredEntity.ValidateAccess(securedEntity, new ApplicationUser(), typeof(string)));

            Assert.AreEqual(
                SecuredEntityValidatorImpl<SecuredEntityWithTechnicalKey>.EXCEPTION_MESSAGE_CURRENT_USER_GAMING_GROUP_ID_CANNOT_BE_NULL, 
                exception.Message);
        }
    }
}
