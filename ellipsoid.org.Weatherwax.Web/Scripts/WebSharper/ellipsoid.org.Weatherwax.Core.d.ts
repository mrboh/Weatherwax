declare module ellipsoid {
    module org {
        module Weatherwax {
            module Core {
                module ClientDirectives {
                    var NgView : {
                        <_M1>(x: __ABBREV.__WebSharper.seq<_M1>): __ABBREV.__Client.Element;
                    };
                    var UIView : {
                        <_M1>(x: __ABBREV.__WebSharper.seq<_M1>): __ABBREV.__Client.Element;
                    };
                    var NgBindHtml : {
                        (x: string): __ABBREV.__Client.Pagelet;
                    };
                    var NgController : {
                        (x: string): __ABBREV.__Client.Pagelet;
                    };
                    var NgClass : {
                        (x: string): __ABBREV.__Client.Pagelet;
                    };
                    var NgHide : {
                        (x: string): __ABBREV.__Client.Pagelet;
                    };
                    var NgHref : {
                        (x: string): __ABBREV.__Client.Pagelet;
                    };
                    var NgRepeat : {
                        (x: string): __ABBREV.__Client.Pagelet;
                    };
                    var NgShow : {
                        (x: string): __ABBREV.__Client.Pagelet;
                    };
                    var NgSrc : {
                        (x: string): __ABBREV.__Client.Pagelet;
                    };
                    var SRef : {
                        (x: string): __ABBREV.__Client.Pagelet;
                    };
                }
                module Utilities {
                    interface UntypedStateManager {
                    }
                    var Module_Controller : {
                        (_this: __ABBREV.__SharpAngles.Module, controller: __ABBREV.__Core.WeatherwaxController): __ABBREV.__SharpAngles.Module;
                    };
                    var Module_Controllers : {
                        (_this: __ABBREV.__SharpAngles.Module, controllers: __ABBREV.__List.T<__ABBREV.__Core.WeatherwaxController>): __ABBREV.__SharpAngles.Module;
                    };
                    var Module_States : {
                        (_this: __ABBREV.__SharpAngles.Module, stateDefinitions: any[], otherwise: __ABBREV.__WebSharper.OptionProxy<string>, redirects: __ABBREV.__WebSharper.OptionProxy<any[]>): __ABBREV.__SharpAngles.Module;
                    };
                    var InjectorService_TransitionToState : {
                        (_this: __ABBREV.__Auto.InjectorService, newState: string): void;
                    };
                }
                module Dependencies {
                    module Other {
                        var StateParams : {
                            <_M1>(): __ABBREV.__Core.Dependency<_M1>;
                        };
                    }
                    module Providers {
                        var Location : {
                            (): __ABBREV.__Core.Dependency<__ABBREV.__SharpAngles.LocationProvider>;
                        };
                        var State : {
                            (): __ABBREV.__Core.Dependency<__ABBREV.__UI.StateProvider>;
                        };
                        var UrlMatcherFactory : {
                            (): __ABBREV.__Core.Dependency<__ABBREV.__UI.UrlMatcherFactory>;
                        };
                        var UrlRouter : {
                            (): __ABBREV.__Core.Dependency<__ABBREV.__UI.UrlRouterProvider>;
                        };
                    }
                    module Services {
                        var CustomScope : {
                            <_M1>(): __ABBREV.__Core.Dependency<_M1>;
                        };
                        var Location : {
                            (): __ABBREV.__Core.Dependency<__ABBREV.__SharpAngles.LocationService>;
                        };
                        var RootScope : {
                            (): __ABBREV.__Core.Dependency<__ABBREV.__SharpAngles.RootScopeService>;
                        };
                        var Route : {
                            (): __ABBREV.__Core.Dependency<__ABBREV.__Route.RouteService>;
                        };
                        var Sce : {
                            (): __ABBREV.__Core.Dependency<__ABBREV.__SharpAngles.SCEService>;
                        };
                        var Scope : {
                            (): __ABBREV.__Core.Dependency<any>;
                        };
                        var State : {
                            (): __ABBREV.__Core.Dependency<__ABBREV.__UI.StateService>;
                        };
                    }
                    module Events {
                        var StateChangeSuccess : {
                            (): string;
                        };
                        var ViewContentLoaded : {
                            (): string;
                        };
                    }
                    var Router : {
                        (): string;
                    };
                    var UIRouter : {
                        (): string;
                    };
                }
                interface Dependency<_T1> {
                    get_JavascriptName(): string;
                }
                interface AngularExpression0 {
                    Resolve<_M1>(lambda: {
                        (): _M1;
                    }): __ABBREV.__WebSharper.ObjectProxy;
                }
                interface AngularExpression1<_T1> {
                    Resolve<_M1>(lambda: {
                        (x: _T1): _M1;
                    }): __ABBREV.__WebSharper.ObjectProxy;
                }
                interface AngularExpression2<_T1, _T2> {
                    Resolve<_M1>(lambda: __ABBREV.__WebSharper.F2<_T1, _T2, _M1>): __ABBREV.__WebSharper.ObjectProxy;
                }
                interface AngularExpression3<_T1, _T2, _T3> {
                    Resolve<_M1>(lambda: __ABBREV.__WebSharper.F3<_T1, _T2, _T3, _M1>): __ABBREV.__WebSharper.ObjectProxy;
                }
                interface WeatherwaxError {
                }
                interface WeatherwaxAction {
                }
                interface ISettings {
                    GenerateSnapshot(baseUrl: string, fragment: string): string;
                    get_ClientControl(): __ABBREV.__Web.Control;
                    get_FileTemplateRootPath(): string;
                    get_MainHtmlPath(): string;
                    get_TemplateHtmlPath(): string;
                }
                interface TemplateFile {
                }
                interface WeatherwaxController {
                    FromSourceFilename(f: string): string;
                }
                interface Template<_T1> {
                }
                interface WeatherwaxBaseState {
                }
                interface WeatherwaxState<_T1> {
                }
                interface StateDefinition {
                    Name: string;
                    Url: __ABBREV.__WebSharper.OptionProxy<string>;
                    UrlParametersToPassToTemplate: __ABBREV.__List.T<string>;
                    ControllerName: __ABBREV.__WebSharper.OptionProxy<string>;
                    CustomData: __ABBREV.__WebSharper.OptionProxy<__ABBREV.__WebSharper.ObjectProxy>;
                }
                interface StateWhen {
                    UrlIn: string;
                    UrlOut: string;
                }
                interface Parameter<_T1> {
                }
                interface StringParameter {
                }
                interface IntParameter {
                }
                interface FloatParameter {
                }
                interface InheritableProperty<_T1> {
                    value: _T1;
                }
                interface WebSharperTemplateBase {
                    Body: __ABBREV.__List.T<any>;
                }
                interface AngularTemplateBase {
                    Content: __ABBREV.__List.T<any>;
                }
                interface WeatherwaxWebsite<_T1> {
                }
            }
        }
    }
}
declare module IntelliFactory {
    module WebSharper {
        interface F2<_T1, _T2, _T3> {
            (a1: _T1, a2: _T2): _T3;
            (tuple: {
                0: _T1;
                1: _T2;
            }): _T3;
        }
        interface F3<_T1, _T2, _T3, _T4> {
            (a1: _T1, a2: _T2, a3: _T3): _T4;
            (tuple: {
                0: _T1;
                1: _T2;
                2: _T3;
            }): _T4;
        }
    }
}
declare module __ABBREV {
    
    export import __WebSharper = IntelliFactory.WebSharper;
    export import __Client = IntelliFactory.WebSharper.Html.Client;
    export import __SharpAngles = ellipsoid.org.SharpAngles;
    export import __Core = ellipsoid.org.Weatherwax.Core;
    export import __List = IntelliFactory.WebSharper.List;
    export import __Auto = ellipsoid.org.SharpAngles.Auto;
    export import __UI = ellipsoid.org.SharpAngles.UI;
    export import __Route = ellipsoid.org.SharpAngles.Route;
    export import __Web = IntelliFactory.WebSharper.Web;
}
