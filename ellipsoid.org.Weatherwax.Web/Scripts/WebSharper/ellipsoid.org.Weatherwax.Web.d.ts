declare module ellipsoid {
    module org {
        module Weatherwax {
            module Web {
                module Controllers {
                    interface BaseController {
                        get_Name(): string;
                        get_Implementation(): __ABBREV.__WebSharper.ObjectProxy;
                    }
                    interface HomeController {
                        get_Name(): string;
                        get_Implementation(): __ABBREV.__WebSharper.ObjectProxy;
                    }
                    interface AboutController {
                        get_Name(): string;
                        get_Implementation(): __ABBREV.__WebSharper.ObjectProxy;
                    }
                    interface MusicController {
                        get_Name(): string;
                        get_Implementation(): __ABBREV.__WebSharper.ObjectProxy;
                    }
                    interface ErrorController {
                        get_Name(): string;
                        get_Implementation(): __ABBREV.__WebSharper.ObjectProxy;
                    }
                }
                module States {
                    interface MasterState {
                    }
                    interface Master_HomeState {
                    }
                    interface Master_AboutState {
                    }
                    interface Master_MusicState {
                    }
                    interface Master_ErrorState {
                    }
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
                interface AngularState {
                }
                interface StateDefinitionService {
                    States: any[];
                }
                interface Settings {
                }
            }
        }
    }
}
declare module __ABBREV {
    
    export import __WebSharper = IntelliFactory.WebSharper;
}
