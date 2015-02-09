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
                    var Module_Controllers : {
                        <_M1>(_this: __ABBREV.__SharpAngles.Module, config: __ABBREV.__Core.ControllerConfiguration<_M1>): __ABBREV.__SharpAngles.Module;
                    };
                    var Module_States : {
                        <_M1, _M2, _M3>(_this: __ABBREV.__SharpAngles.Module, config: __ABBREV.__Core.StateConfiguration<_M1, _M2, _M3>, nameMapper: {
                            (x: _M3): string;
                        }, templateRelativePath: {
                            (x: _M1): string;
                        }, controllerConfig: __ABBREV.__Core.ControllerConfiguration<_M2>): __ABBREV.__SharpAngles.Module;
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
                        var RootScope : {
                            (): __ABBREV.__Core.Dependency<__ABBREV.__SharpAngles.RootScopeService>;
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
                interface ControllerInfo<_T1> {
                    Controller: _T1;
                    Name: string;
                    Implementation: __ABBREV.__WebSharper.ObjectProxy;
                }
                interface ControllerConfiguration<_T1> {
                    DefineController<_M1>(controller: _T1, name: string, implementation: _M1): __ABBREV.__Core.ControllerConfiguration<_T1>;
                    ControllerName(controller: _T1): string;
                    get_Controllers(): __ABBREV.__List.T<any>;
                }
                interface StateTemplateReference<_T1> {
                }
                interface IState<_T1, _T2> {
                    get_Url(): __ABBREV.__WebSharper.OptionProxy<string>;
                    get_Template(): __ABBREV.__Core.StateTemplateReference<_T1>;
                    get_Controller(): __ABBREV.__WebSharper.OptionProxy<_T2>;
                }
                interface StateInfo<_T1, _T2, _T3> {
                    State: _T3;
                    Name: string;
                    Implementation: __ABBREV.__Core.IState<_T1, _T2>;
                }
                interface StateConfiguration<_T1, _T2, _T3> {
                    DefineState(state: _T3, implementation: __ABBREV.__Core.IState<_T1, _T2>): __ABBREV.__Core.StateConfiguration<_T1, _T2, _T3>;
                    When(whenPath: string, toPath: string): __ABBREV.__Core.StateConfiguration<_T1, _T2, _T3>;
                    Otherwise(): __ABBREV.__WebSharper.OptionProxy<string>;
                    Otherwise1(path: string): __ABBREV.__Core.StateConfiguration<_T1, _T2, _T3>;
                    get_States(): __ABBREV.__List.T<any>;
                    get_Whens(): __ABBREV.__List.T<any>;
                }
                interface TemplateFile {
                }
                interface Template {
                }
                interface ISettings<_T1, _T2, _T3> {
                    GenerateSnapshot(baseUrl: string, fragment: string): string;
                    TemplateRelativePath(x0: _T1): string;
                    TemplateImplementation(x0: _T1): __ABBREV.__Core.Template;
                    get_ClientControl(): __ABBREV.__Web.Control;
                    get_ControllerConfiguration(): __ABBREV.__Core.ControllerConfiguration<_T2>;
                    get_FileTemplateRootPath(): string;
                    get_MainHtmlPath(): string;
                    get_StateConfiguration(): __ABBREV.__Core.StateConfiguration<_T1, _T2, _T3>;
                    get_TemplateHtmlPath(): string;
                }
                interface WeatherwaxError {
                }
                interface Action<_T1> {
                }
                interface WebSharperTemplateBase {
                    Body: __ABBREV.__List.T<any>;
                }
                interface AngularTemplateBase {
                    Content: __ABBREV.__List.T<any>;
                }
                interface AngularWebsite<_T1, _T2, _T3> {
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
    export import __UI = ellipsoid.org.SharpAngles.UI;
    export import __List = IntelliFactory.WebSharper.List;
    export import __Web = IntelliFactory.WebSharper.Web;
}
