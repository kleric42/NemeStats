﻿using BusinessLogic.EventTracking;
using NUnit.Framework;
using Rhino.Mocks;
using System.Linq;

namespace BusinessLogic.Tests.UnitTests.EventTrackingTests.UniversalAnalyticsNemeStatsEventTrackerTests
{
    [TestFixture]
    public class TrackUserRegistrationTests : UniversalAnalyticsNemeStatsEventTrackerTestBase
    {
        [Test]
        public void ItSetsTheAnonymousClientId()
        {
            eventFactoryMock.Expect(mock => mock.MakeUniversalAnalyticsEvent(
                Arg<string>.Is.Equal(UniversalAnalyticsNemeStatsEventTracker.DEFAULT_ANONYMOUS_CLIENT_ID),
                Arg<string>.Is.Anything,
                Arg<string>.Is.Anything,
                Arg<string>.Is.Anything,
                Arg<string>.Is.Anything))
                .Return(analyticsEvent);

            tracker.TrackUserRegistration();

            eventTrackerMock.AssertWasCalled(mock => mock.TrackEvent(analyticsEvent));
        }

        [Test]
        public void ItSetsTheEventCategoryToUsers()
        {
            eventFactoryMock.Expect(mock => mock.MakeUniversalAnalyticsEvent(
                Arg<string>.Is.Anything,
                Arg<string>.Is.Equal(EventCategoryEnum.Users.ToString()),
                Arg<string>.Is.Anything,
                Arg<string>.Is.Anything,
                Arg<string>.Is.Anything))
                .Return(analyticsEvent);

            tracker.TrackUserRegistration();

            eventTrackerMock.AssertWasCalled(mock => mock.TrackEvent(analyticsEvent));
        }

        [Test]
        public void ItSetsTheEventActionToCreated()
        {
            eventFactoryMock.Expect(mock => mock.MakeUniversalAnalyticsEvent(
                Arg<string>.Is.Anything,
                Arg<string>.Is.Anything,
                Arg<string>.Is.Equal(EventActionEnum.Created.ToString()),
                Arg<string>.Is.Anything,
                Arg<string>.Is.Anything))
                .Return(analyticsEvent);

            tracker.TrackUserRegistration();

            eventTrackerMock.AssertWasCalled(mock => mock.TrackEvent(analyticsEvent));
        }

        [Test]
        public void ItSetsTheLabelToDefault()
        {
            eventFactoryMock.Expect(mock => mock.MakeUniversalAnalyticsEvent(
                Arg<string>.Is.Anything,
                Arg<string>.Is.Anything,
                Arg<string>.Is.Anything,
                Arg<string>.Is.Equal(UniversalAnalyticsNemeStatsEventTracker.DEFAULT_EVENT_LABEL),
                Arg<string>.Is.Anything))
                .Return(analyticsEvent);

            tracker.TrackUserRegistration();

            eventTrackerMock.AssertWasCalled(mock => mock.TrackEvent(analyticsEvent));
        }
    }
}
