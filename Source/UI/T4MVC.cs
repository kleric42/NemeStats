﻿// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments and CLS compliance
// 0108: suppress "Foo hides inherited member Foo. Use the new keyword if hiding was intended." when a controller and its abstract parent are both processed
// 0114: suppress "Foo.BarController.Baz()' hides inherited member 'Qux.BarController.Baz()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword." when an action (with an argument) overrides an action in a parent controller
#pragma warning disable 1591, 3008, 3009, 0108, 0114
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;

[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
public static partial class MVC
{
    static readonly ApiClass s_Api = new ApiClass();
    public static ApiClass Api { get { return s_Api; } }
    public static UI.Controllers.AccountController Account = new UI.Controllers.T4MVC_AccountController();
    public static UI.Controllers.GameDefinitionController GameDefinition = new UI.Controllers.T4MVC_GameDefinitionController();
    public static UI.Controllers.GamingGroupController GamingGroup = new UI.Controllers.T4MVC_GamingGroupController();
    public static UI.Controllers.Helpers.BaseController Base = new UI.Controllers.Helpers.T4MVC_BaseController();
    public static UI.Controllers.HomeController Home = new UI.Controllers.T4MVC_HomeController();
    public static UI.Controllers.PlayedGameController PlayedGame = new UI.Controllers.T4MVC_PlayedGameController();
    public static UI.Controllers.PlayerController Player = new UI.Controllers.T4MVC_PlayerController();
    public static T4MVC.SharedController Shared = new T4MVC.SharedController();
}

namespace T4MVC
{
    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class ApiClass
    {
        public readonly string Name = "Api";
        public T4MVC.Api.SharedController Shared = new T4MVC.Api.SharedController();
    }
}

namespace T4MVC
{
    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class Dummy
    {
        private Dummy() { }
        public static Dummy Instance = new Dummy();
    }
}

[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
internal partial class T4MVC_System_Web_Mvc_ActionResult : System.Web.Mvc.ActionResult, IT4MVCActionResult
{
    public T4MVC_System_Web_Mvc_ActionResult(string area, string controller, string action, string protocol = null): base()
    {
        this.InitMVCT4Result(area, controller, action, protocol);
    }
     
    public override void ExecuteResult(System.Web.Mvc.ControllerContext context) { }
    
    public string Controller { get; set; }
    public string Action { get; set; }
    public string Protocol { get; set; }
    public RouteValueDictionary RouteValueDictionary { get; set; }
}



namespace Links
{
    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public static class Scripts {
        private const string URLPATH = "~/Scripts";
        public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
        public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
        public static readonly string _references_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/_references.min.js") ? Url("_references.min.js") : Url("_references.js");
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class CreatePlayedGame {
            private const string URLPATH = "~/Scripts/CreatePlayedGame";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
            public static readonly string createplayedgame_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/createplayedgame.min.js") ? Url("createplayedgame.min.js") : Url("createplayedgame.js");
        }
    
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class d3 {
            private const string URLPATH = "~/Scripts/d3";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public static class css {
                private const string URLPATH = "~/Scripts/d3/css";
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
                public static readonly string nv_d3_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/nv.d3.min.css") ? Url("nv.d3.min.css") : Url("nv.d3.css");
            }
        
            public static readonly string d3_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/d3.min.js") ? Url("d3.min.js") : Url("d3.js");
            public static readonly string d3_min_js = Url("d3.min.js");
            public static readonly string LICENSE = Url("LICENSE");
            public static readonly string nv_d3_min_js = Url("nv.d3.min.js");
        }
    
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class GameDefinition {
            private const string URLPATH = "~/Scripts/GameDefinition";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
            public static readonly string createGameDefinition_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/createGameDefinition.min.js") ? Url("createGameDefinition.min.js") : Url("createGameDefinition.js");
            public static readonly string createGameDefinitionPartial_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/createGameDefinitionPartial.min.js") ? Url("createGameDefinitionPartial.min.js") : Url("createGameDefinitionPartial.js");
            public static readonly string gameDefinitionAutoComplete_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/gameDefinitionAutoComplete.min.js") ? Url("gameDefinitionAutoComplete.min.js") : Url("gameDefinitionAutoComplete.js");
            public static readonly string gameDefinitions_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/gameDefinitions.min.js") ? Url("gameDefinitions.min.js") : Url("gameDefinitions.js");
        }
    
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class GamingGroup {
            private const string URLPATH = "~/Scripts/GamingGroup";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
            public static readonly string gamingGroup_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/gamingGroup.min.js") ? Url("gamingGroup.min.js") : Url("gamingGroup.js");
        }
    
        public static readonly string handlebars_amd_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/handlebars.amd.min.js") ? Url("handlebars.amd.min.js") : Url("handlebars.amd.js");
        public static readonly string handlebars_amd_min_js = Url("handlebars.amd.min.js");
        public static readonly string handlebars_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/handlebars.min.js") ? Url("handlebars.min.js") : Url("handlebars.js");
        public static readonly string handlebars_min_js = Url("handlebars.min.js");
        public static readonly string handlebars_runtime_amd_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/handlebars.runtime.amd.min.js") ? Url("handlebars.runtime.amd.min.js") : Url("handlebars.runtime.amd.js");
        public static readonly string handlebars_runtime_amd_min_js = Url("handlebars.runtime.amd.min.js");
        public static readonly string handlebars_runtime_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/handlebars.runtime.min.js") ? Url("handlebars.runtime.min.js") : Url("handlebars.runtime.js");
        public static readonly string handlebars_runtime_min_js = Url("handlebars.runtime.min.js");
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class Idea_Informer {
            private const string URLPATH = "~/Scripts/Idea.Informer";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
            public static readonly string tab6_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/tab6.min.js") ? Url("tab6.min.js") : Url("tab6.js");
        }
    
        public static readonly string jquery_1_10_2_intellisense_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/jquery-1.10.2.intellisense.min.js") ? Url("jquery-1.10.2.intellisense.min.js") : Url("jquery-1.10.2.intellisense.js");
        public static readonly string jquery_1_10_2_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/jquery-1.10.2.min.js") ? Url("jquery-1.10.2.min.js") : Url("jquery-1.10.2.js");
        public static readonly string jquery_1_10_2_min_js = Url("jquery-1.10.2.min.js");
        public static readonly string jquery_2_1_4_intellisense_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/jquery-2.1.4.intellisense.min.js") ? Url("jquery-2.1.4.intellisense.min.js") : Url("jquery-2.1.4.intellisense.js");
        public static readonly string jquery_2_1_4_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/jquery-2.1.4.min.js") ? Url("jquery-2.1.4.min.js") : Url("jquery-2.1.4.js");
        public static readonly string jquery_2_1_4_min_js = Url("jquery-2.1.4.min.js");
        public static readonly string jquery_2_1_4_min_map = Url("jquery-2.1.4.min.map");
        public static readonly string jquery_ui_1_11_4_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/jquery-ui-1.11.4.min.js") ? Url("jquery-ui-1.11.4.min.js") : Url("jquery-ui-1.11.4.js");
        public static readonly string jquery_ui_1_11_4_min_js = Url("jquery-ui-1.11.4.min.js");
        public static readonly string jquery_cookie_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/jquery.cookie.min.js") ? Url("jquery.cookie.min.js") : Url("jquery.cookie.js");
        public static readonly string jquery_validate_vsdoc_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/jquery.validate-vsdoc.min.js") ? Url("jquery.validate-vsdoc.min.js") : Url("jquery.validate-vsdoc.js");
        public static readonly string jquery_validate_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/jquery.validate.min.js") ? Url("jquery.validate.min.js") : Url("jquery.validate.js");
        public static readonly string jquery_validate_min_js = Url("jquery.validate.min.js");
        public static readonly string jquery_validate_unobtrusive_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/jquery.validate.unobtrusive.min.js") ? Url("jquery.validate.unobtrusive.min.js") : Url("jquery.validate.unobtrusive.js");
        public static readonly string jquery_validate_unobtrusive_min_js = Url("jquery.validate.unobtrusive.min.js");
        public static readonly string moment_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/moment.min.js") ? Url("moment.min.js") : Url("moment.js");
        public static readonly string moment_min_js = Url("moment.min.js");
        public static readonly string namespace_1_0_0_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/namespace-1.0.0.min.js") ? Url("namespace-1.0.0.min.js") : Url("namespace-1.0.0.js");
        public static readonly string namespace_min_1_0_0_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/namespace.min-1.0.0.min.js") ? Url("namespace.min-1.0.0.min.js") : Url("namespace.min-1.0.0.js");
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class PlayedGame {
            private const string URLPATH = "~/Scripts/PlayedGame";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
            public static readonly string recordexceldownload_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/recordexceldownload.min.js") ? Url("recordexceldownload.min.js") : Url("recordexceldownload.js");
            public static readonly string search_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/search.min.js") ? Url("search.min.js") : Url("search.js");
        }
    
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class Player {
            private const string URLPATH = "~/Scripts/Player";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
            public static readonly string createOrUpdatePlayer_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/createOrUpdatePlayer.min.js") ? Url("createOrUpdatePlayer.min.js") : Url("createOrUpdatePlayer.js");
            public static readonly string playerDetails_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/playerDetails.min.js") ? Url("playerDetails.min.js") : Url("playerDetails.js");
            public static readonly string players_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/players.min.js") ? Url("players.min.js") : Url("players.js");
        }
    
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class Plugins {
            private const string URLPATH = "~/Scripts/Plugins";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
            public static readonly string rankPlugin_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/rankPlugin.min.js") ? Url("rankPlugin.min.js") : Url("rankPlugin.js");
            public static readonly string toEditBoxPlugin_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/toEditBoxPlugin.min.js") ? Url("toEditBoxPlugin.min.js") : Url("toEditBoxPlugin.js");
        }
    
        public static readonly string respond_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/respond.min.js") ? Url("respond.min.js") : Url("respond.js");
        public static readonly string respond_min_js = Url("respond.min.js");
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class Shared {
            private const string URLPATH = "~/Scripts/Shared";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
            public static readonly string _Layout_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/_Layout.min.js") ? Url("_Layout.min.js") : Url("_Layout.js");
            public static readonly string GoogleAnalytics_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/GoogleAnalytics.min.js") ? Url("GoogleAnalytics.min.js") : Url("GoogleAnalytics.js");
        }
    
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public static class Content {
        private const string URLPATH = "~/Content";
        public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
        public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
        public static readonly string font_awesome_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/font-awesome.min.css") ? Url("font-awesome.min.css") : Url("font-awesome.css");
        public static readonly string font_awesome_min_css = Url("font-awesome.min.css");
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class Images {
            private const string URLPATH = "~/Content/Images";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
            public static readonly string bgg_small_png = Url("bgg_small.png");
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public static class Home {
                private const string URLPATH = "~/Content/Images/Home";
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
                public static readonly string Banner_jpg = Url("Banner.jpg");
            }
        
            public static readonly string NemeStats_White_png = Url("NemeStats-White.png");
            public static readonly string NemeStats_png = Url("NemeStats.png");
            public static readonly string spinner_gif = Url("spinner.gif");
        }
    
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class themes {
            private const string URLPATH = "~/Content/themes";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public static class @base {
                private const string URLPATH = "~/Content/themes/base";
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
                public static readonly string accordion_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/accordion.min.css") ? Url("accordion.min.css") : Url("accordion.css");
                public static readonly string all_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/all.min.css") ? Url("all.min.css") : Url("all.css");
                public static readonly string autocomplete_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/autocomplete.min.css") ? Url("autocomplete.min.css") : Url("autocomplete.css");
                public static readonly string base_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/base.min.css") ? Url("base.min.css") : Url("base.css");
                public static readonly string button_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/button.min.css") ? Url("button.min.css") : Url("button.css");
                public static readonly string core_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/core.min.css") ? Url("core.min.css") : Url("core.css");
                public static readonly string datepicker_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/datepicker.min.css") ? Url("datepicker.min.css") : Url("datepicker.css");
                public static readonly string dialog_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/dialog.min.css") ? Url("dialog.min.css") : Url("dialog.css");
                public static readonly string draggable_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/draggable.min.css") ? Url("draggable.min.css") : Url("draggable.css");
                [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
                public static class images {
                    private const string URLPATH = "~/Content/themes/base/images";
                    public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
                    public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
                    public static readonly string ui_bg_flat_0_aaaaaa_40x100_png = Url("ui-bg_flat_0_aaaaaa_40x100.png");
                    public static readonly string ui_bg_flat_75_ffffff_40x100_png = Url("ui-bg_flat_75_ffffff_40x100.png");
                    public static readonly string ui_bg_glass_55_fbf9ee_1x400_png = Url("ui-bg_glass_55_fbf9ee_1x400.png");
                    public static readonly string ui_bg_glass_65_ffffff_1x400_png = Url("ui-bg_glass_65_ffffff_1x400.png");
                    public static readonly string ui_bg_glass_75_dadada_1x400_png = Url("ui-bg_glass_75_dadada_1x400.png");
                    public static readonly string ui_bg_glass_75_e6e6e6_1x400_png = Url("ui-bg_glass_75_e6e6e6_1x400.png");
                    public static readonly string ui_bg_glass_95_fef1ec_1x400_png = Url("ui-bg_glass_95_fef1ec_1x400.png");
                    public static readonly string ui_bg_highlight_soft_75_cccccc_1x100_png = Url("ui-bg_highlight-soft_75_cccccc_1x100.png");
                    public static readonly string ui_icons_222222_256x240_png = Url("ui-icons_222222_256x240.png");
                    public static readonly string ui_icons_2e83ff_256x240_png = Url("ui-icons_2e83ff_256x240.png");
                    public static readonly string ui_icons_454545_256x240_png = Url("ui-icons_454545_256x240.png");
                    public static readonly string ui_icons_888888_256x240_png = Url("ui-icons_888888_256x240.png");
                    public static readonly string ui_icons_cd0a0a_256x240_png = Url("ui-icons_cd0a0a_256x240.png");
                }
            
                public static readonly string jquery_ui_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/jquery-ui.min.css") ? Url("jquery-ui.min.css") : Url("jquery-ui.css");
                public static readonly string jquery_ui_min_css = Url("jquery-ui.min.css");
                public static readonly string menu_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/menu.min.css") ? Url("menu.min.css") : Url("menu.css");
                public static readonly string progressbar_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/progressbar.min.css") ? Url("progressbar.min.css") : Url("progressbar.css");
                public static readonly string resizable_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/resizable.min.css") ? Url("resizable.min.css") : Url("resizable.css");
                public static readonly string selectable_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/selectable.min.css") ? Url("selectable.min.css") : Url("selectable.css");
                public static readonly string selectmenu_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/selectmenu.min.css") ? Url("selectmenu.min.css") : Url("selectmenu.css");
                public static readonly string slider_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/slider.min.css") ? Url("slider.min.css") : Url("slider.css");
                public static readonly string sortable_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/sortable.min.css") ? Url("sortable.min.css") : Url("sortable.css");
                public static readonly string spinner_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/spinner.min.css") ? Url("spinner.min.css") : Url("spinner.css");
                public static readonly string tabs_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/tabs.min.css") ? Url("tabs.min.css") : Url("tabs.css");
                public static readonly string theme_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/theme.min.css") ? Url("theme.min.css") : Url("theme.css");
                public static readonly string tooltip_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/tooltip.min.css") ? Url("tooltip.min.css") : Url("tooltip.css");
            }
        
        }
    
    }

    
    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public static partial class Bundles
    {
        public static partial class Scripts 
        {
            public static partial class CreatePlayedGame 
            {
                public static class Assets
                {
                    public const string createplayedgame_js = "~/Scripts/CreatePlayedGame/createplayedgame.js"; 
                }
            }
            public static partial class d3 
            {
                public static partial class css 
                {
                    public static class Assets
                    {
                        public const string nv_d3_css = "~/Scripts/d3/css/nv.d3.css";
                    }
                }
                public static class Assets
                {
                    public const string d3_js = "~/Scripts/d3/d3.js"; 
                    public const string d3_min_js = "~/Scripts/d3/d3.min.js"; 
                    public const string nv_d3_min_js = "~/Scripts/d3/nv.d3.min.js"; 
                }
            }
            public static partial class GameDefinition 
            {
                public static class Assets
                {
                    public const string createGameDefinition_js = "~/Scripts/GameDefinition/createGameDefinition.js"; 
                    public const string createGameDefinitionPartial_js = "~/Scripts/GameDefinition/createGameDefinitionPartial.js"; 
                    public const string gameDefinitionAutoComplete_js = "~/Scripts/GameDefinition/gameDefinitionAutoComplete.js"; 
                    public const string gameDefinitions_js = "~/Scripts/GameDefinition/gameDefinitions.js"; 
                }
            }
            public static partial class GamingGroup 
            {
                public static class Assets
                {
                    public const string gamingGroup_js = "~/Scripts/GamingGroup/gamingGroup.js"; 
                }
            }
            public static partial class Idea_Informer 
            {
                public static class Assets
                {
                    public const string tab6_js = "~/Scripts/Idea.Informer/tab6.js"; 
                }
            }
            public static partial class PlayedGame 
            {
                public static class Assets
                {
                    public const string recordexceldownload_js = "~/Scripts/PlayedGame/recordexceldownload.js"; 
                    public const string search_js = "~/Scripts/PlayedGame/search.js"; 
                }
            }
            public static partial class Player 
            {
                public static class Assets
                {
                    public const string createOrUpdatePlayer_js = "~/Scripts/Player/createOrUpdatePlayer.js"; 
                    public const string playerDetails_js = "~/Scripts/Player/playerDetails.js"; 
                    public const string players_js = "~/Scripts/Player/players.js"; 
                }
            }
            public static partial class Plugins 
            {
                public static class Assets
                {
                    public const string rankPlugin_js = "~/Scripts/Plugins/rankPlugin.js"; 
                    public const string toEditBoxPlugin_js = "~/Scripts/Plugins/toEditBoxPlugin.js"; 
                }
            }
            public static partial class Shared 
            {
                public static class Assets
                {
                    public const string _Layout_js = "~/Scripts/Shared/_Layout.js"; 
                    public const string GoogleAnalytics_js = "~/Scripts/Shared/GoogleAnalytics.js"; 
                }
            }
            public static class Assets
            {
                public const string _references_js = "~/Scripts/_references.js"; 
                public const string handlebars_amd_js = "~/Scripts/handlebars.amd.js"; 
                public const string handlebars_amd_min_js = "~/Scripts/handlebars.amd.min.js"; 
                public const string handlebars_js = "~/Scripts/handlebars.js"; 
                public const string handlebars_min_js = "~/Scripts/handlebars.min.js"; 
                public const string handlebars_runtime_amd_js = "~/Scripts/handlebars.runtime.amd.js"; 
                public const string handlebars_runtime_amd_min_js = "~/Scripts/handlebars.runtime.amd.min.js"; 
                public const string handlebars_runtime_js = "~/Scripts/handlebars.runtime.js"; 
                public const string handlebars_runtime_min_js = "~/Scripts/handlebars.runtime.min.js"; 
                public const string jquery_1_10_2_intellisense_js = "~/Scripts/jquery-1.10.2.intellisense.js"; 
                public const string jquery_1_10_2_js = "~/Scripts/jquery-1.10.2.js"; 
                public const string jquery_1_10_2_min_js = "~/Scripts/jquery-1.10.2.min.js"; 
                public const string jquery_2_1_4_intellisense_js = "~/Scripts/jquery-2.1.4.intellisense.js"; 
                public const string jquery_2_1_4_js = "~/Scripts/jquery-2.1.4.js"; 
                public const string jquery_2_1_4_min_js = "~/Scripts/jquery-2.1.4.min.js"; 
                public const string jquery_ui_1_11_4_js = "~/Scripts/jquery-ui-1.11.4.js"; 
                public const string jquery_ui_1_11_4_min_js = "~/Scripts/jquery-ui-1.11.4.min.js"; 
                public const string jquery_cookie_js = "~/Scripts/jquery.cookie.js"; 
                public const string jquery_validate_js = "~/Scripts/jquery.validate.js"; 
                public const string jquery_validate_min_js = "~/Scripts/jquery.validate.min.js"; 
                public const string jquery_validate_unobtrusive_js = "~/Scripts/jquery.validate.unobtrusive.js"; 
                public const string jquery_validate_unobtrusive_min_js = "~/Scripts/jquery.validate.unobtrusive.min.js"; 
                public const string moment_js = "~/Scripts/moment.js"; 
                public const string moment_min_js = "~/Scripts/moment.min.js"; 
                public const string namespace_1_0_0_js = "~/Scripts/namespace-1.0.0.js"; 
                public const string namespace_min_1_0_0_js = "~/Scripts/namespace.min-1.0.0.js"; 
                public const string respond_js = "~/Scripts/respond.js"; 
                public const string respond_min_js = "~/Scripts/respond.min.js"; 
            }
        }
        public static partial class Content 
        {
            public static partial class Images 
            {
                public static partial class Home 
                {
                    public static class Assets
                    {
                    }
                }
                public static class Assets
                {
                }
            }
            public static partial class themes 
            {
                public static partial class @base 
                {
                    public static partial class images 
                    {
                        public static class Assets
                        {
                        }
                    }
                    public static class Assets
                    {
                        public const string accordion_css = "~/Content/themes/base/accordion.css";
                        public const string all_css = "~/Content/themes/base/all.css";
                        public const string autocomplete_css = "~/Content/themes/base/autocomplete.css";
                        public const string base_css = "~/Content/themes/base/base.css";
                        public const string button_css = "~/Content/themes/base/button.css";
                        public const string core_css = "~/Content/themes/base/core.css";
                        public const string datepicker_css = "~/Content/themes/base/datepicker.css";
                        public const string dialog_css = "~/Content/themes/base/dialog.css";
                        public const string draggable_css = "~/Content/themes/base/draggable.css";
                        public const string jquery_ui_css = "~/Content/themes/base/jquery-ui.css";
                        public const string jquery_ui_min_css = "~/Content/themes/base/jquery-ui.min.css";
                        public const string menu_css = "~/Content/themes/base/menu.css";
                        public const string progressbar_css = "~/Content/themes/base/progressbar.css";
                        public const string resizable_css = "~/Content/themes/base/resizable.css";
                        public const string selectable_css = "~/Content/themes/base/selectable.css";
                        public const string selectmenu_css = "~/Content/themes/base/selectmenu.css";
                        public const string slider_css = "~/Content/themes/base/slider.css";
                        public const string sortable_css = "~/Content/themes/base/sortable.css";
                        public const string spinner_css = "~/Content/themes/base/spinner.css";
                        public const string tabs_css = "~/Content/themes/base/tabs.css";
                        public const string theme_css = "~/Content/themes/base/theme.css";
                        public const string tooltip_css = "~/Content/themes/base/tooltip.css";
                    }
                }
                public static class Assets
                {
                }
            }
            public static class Assets
            {
                public const string font_awesome_css = "~/Content/font-awesome.css";
                public const string font_awesome_min_css = "~/Content/font-awesome.min.css";
            }
        }
    }
}

[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
internal static class T4MVCHelpers {
    // You can change the ProcessVirtualPath method to modify the path that gets returned to the client.
    // e.g. you can prepend a domain, or append a query string:
    //      return "http://localhost" + path + "?foo=bar";
    private static string ProcessVirtualPathDefault(string virtualPath) {
        // The path that comes in starts with ~/ and must first be made absolute
        string path = VirtualPathUtility.ToAbsolute(virtualPath);
        
        // Add your own modifications here before returning the path
        return path;
    }

    // Calling ProcessVirtualPath through delegate to allow it to be replaced for unit testing
    public static Func<string, string> ProcessVirtualPath = ProcessVirtualPathDefault;

    // Calling T4Extension.TimestampString through delegate to allow it to be replaced for unit testing and other purposes
    public static Func<string, string> TimestampString = System.Web.Mvc.T4Extensions.TimestampString;

    // Logic to determine if the app is running in production or dev environment
    public static bool IsProduction() { 
        return (HttpContext.Current != null && !HttpContext.Current.IsDebuggingEnabled); 
    }
}





#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114


