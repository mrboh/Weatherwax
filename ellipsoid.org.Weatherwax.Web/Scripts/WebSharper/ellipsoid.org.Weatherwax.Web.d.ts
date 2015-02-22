declare module ellipsoid {
    module org {
        module Weatherwax {
            module Web {
                module AngularModules {
                    var SiteletApp : {
                        (): __ABBREV.__SharpAngles.Module;
                    };
                }
                module AngularRouter {
                    interface ErrorRouteParameters {
                        id: number;
                    }
                    var SI : {
                        <_M1, _M2>(url: __ABBREV.__WebSharper.OptionProxy<string>, template: __ABBREV.__Core.StateTemplateReference<_M1>, controller: __ABBREV.__WebSharper.OptionProxy<_M2>): any;
                    };
                    var errorTemplate : {
                        (p: __ABBREV.__WebSharper.ObjectProxy): string;
                    };
                    var StateConfiguration : {
                        (): __ABBREV.__Core.StateConfiguration<__ABBREV.__Web.AngularTemplate, __ABBREV.__Web.AngularController, __ABBREV.__AngularStates.AngularState>;
                    };
                }
                module AngularStates {
                    interface AngularState {
                    }
                    interface MasterState {
                    }
                    var subState : {
                        <_M1>(name: string, value: __ABBREV.__WebSharper.OptionProxy<_M1>, matcher: {
                            (x: _M1): string;
                        }): string;
                    };
                    var AngularStateName : {
                        (_arg1: __ABBREV.__AngularStates.AngularState): string;
                    };
                }
                module AngularControllers {
                    interface ErrorRouteParameters {
                        id: number;
                    }
                    var ControllerConfiguration : {
                        (): __ABBREV.__Core.ControllerConfiguration<__ABBREV.__Web.AngularController>;
                    };
                }
                module AngularConfiguration {
                    var UrlConfiguration : {
                        (): __ABBREV.__WebSharper.ObjectProxy;
                    };
                    var UIRouterConfiguration : {
                        (): __ABBREV.__WebSharper.ObjectProxy;
                    };
                }
                module AngularTemplates {
                    var TemplateRelativePath : {
                        (_arg1: __ABBREV.__Web.AngularTemplate): string;
                    };
                }
                module Remoting {
                    interface Song {
                        Title: string;
                        Artist: string;
                        Album: string;
                        PlayCount: number;
                    }
                }
                module Configuration {
                    var AppName : {
                        (): string;
                    };
                }
                interface AngularTemplate {
                }
                interface AngularController {
                }
            }
        }
    }
}
declare module __ABBREV {
    
    export import __SharpAngles = ellipsoid.org.SharpAngles;
    export import __WebSharper = IntelliFactory.WebSharper;
    export import __Core = ellipsoid.org.Weatherwax.Core;
    export import __Web = ellipsoid.org.Weatherwax.Web;
    export import __AngularStates = ellipsoid.org.Weatherwax.Web.AngularStates;
}
