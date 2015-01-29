declare module ellipsoid {
    module org {
        module Weatherwax {
            module Web {
                module AngularModules {
                    var SiteletApp : {
                        (): void;
                    };
                }
                module AngularRouter {
                    interface ErrorRouteParameters {
                        id: number;
                    }
                    var TemplateUrl : {
                        (t: __ABBREV.__AngularTemplates.AngularTemplate): string;
                    };
                    var ControllerName : {
                        (controller: __ABBREV.__AngularControllers.AngularController): string;
                    };
                    var RouteConfiguration : {
                        (): __ABBREV.__WebSharper.ObjectProxy;
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
    
    export import __AngularTemplates = ellipsoid.org.Weatherwax.Web.AngularTemplates;
    export import __AngularControllers = ellipsoid.org.Weatherwax.Web.AngularControllers;
    export import __WebSharper = IntelliFactory.WebSharper;
    export import __Core = ellipsoid.org.Weatherwax.Core;
}
