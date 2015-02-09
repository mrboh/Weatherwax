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
                    interface StateImplementation {
                        get_Url(): __ABBREV.__WebSharper.OptionProxy<string>;
                        get_Template(): __ABBREV.__Core.StateTemplateReference<__ABBREV.__AngularTemplates.AngularTemplate>;
                        get_Controller(): __ABBREV.__WebSharper.OptionProxy<__ABBREV.__AngularControllers.AngularController>;
                    }
                    interface ErrorRouteParameters {
                        id: number;
                    }
                    var errorTemplate : {
                        (p: __ABBREV.__WebSharper.ObjectProxy): string;
                    };
                    var StateConfiguration : {
                        (): __ABBREV.__Core.StateConfiguration<__ABBREV.__AngularTemplates.AngularTemplate, __ABBREV.__AngularControllers.AngularController, __ABBREV.__AngularStates.AngularState>;
                    };
                }
                module AngularTemplates {
                    interface AngularTemplate {
                    }
                    var TemplateRelativePath : {
                        (_arg1: __ABBREV.__AngularTemplates.AngularTemplate): string;
                    };
                }
                module AngularControllers {
                    interface AngularController {
                    }
                    interface ErrorRouteParameters {
                        id: number;
                    }
                    var ControllerConfiguration : {
                        (): __ABBREV.__Core.ControllerConfiguration<__ABBREV.__AngularControllers.AngularController>;
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
                module AngularConfiguration {
                    var UrlConfiguration : {
                        (): __ABBREV.__WebSharper.ObjectProxy;
                    };
                    var UIRouterConfiguration : {
                        (): __ABBREV.__WebSharper.ObjectProxy;
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
            }
        }
    }
}
declare module __ABBREV {
    
    export import __SharpAngles = ellipsoid.org.SharpAngles;
    export import __WebSharper = IntelliFactory.WebSharper;
    export import __Core = ellipsoid.org.Weatherwax.Core;
    export import __AngularTemplates = ellipsoid.org.Weatherwax.Web.AngularTemplates;
    export import __AngularControllers = ellipsoid.org.Weatherwax.Web.AngularControllers;
    export import __AngularStates = ellipsoid.org.Weatherwax.Web.AngularStates;
}
