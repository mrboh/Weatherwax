(function()
{
 var Global=this,Runtime=this.IntelliFactory.Runtime,ellipsoid,org,Weatherwax,Core,AngularExpression1,Dependencies,Providers,ControllerConfiguration,AngularExpression2,Services,jQuery,WebSharper,Html,Client,Default,List,Remoting,AjaxRemotingProvider,Concurrency,Operators,ClientDirectives,T,angular,Web,Configuration,Utilities,AngularConfiguration,AngularRouter,AngularStates,AngularTemplates,AngularControllers,StateConfiguration,PrintfHelpers,AngularModules;
 Runtime.Define(Global,{
  ellipsoid:{
   org:{
    Weatherwax:{
     Web:{
      AngularConfiguration:{
       UIRouterConfiguration:Runtime.Field(function()
       {
        return AngularExpression1.New(Providers.UrlMatcherFactory()).Resolve(function(urlMatcherFactory)
        {
         var value,value1;
         value=urlMatcherFactory.caseInsensitive(true);
         value1=urlMatcherFactory.strictMode(false);
         return;
        });
       }),
       UrlConfiguration:Runtime.Field(function()
       {
        return AngularExpression1.New(Providers.Location()).Resolve(function(locationProvider)
        {
         return locationProvider.html5Mode(false).hashPrefix("!");
        });
       })
      },
      AngularControllers:{
       ControllerConfiguration:Runtime.Field(function()
       {
        return ControllerConfiguration.New().DefineController({
         $:0
        },"BaseController",AngularExpression2.New(Services.Scope(),Services.RootScope()).Resolve(Runtime.Tupled(function(tupledArg)
        {
         var scope,rootScope,value;
         scope=tupledArg[0];
         rootScope=tupledArg[1];
         value=rootScope.$on("$viewContentLoaded",function()
         {
          var matchValue,_,element,value1;
          matchValue=jQuery("#compositionComplete").length;
          if(matchValue===0)
           {
            element=Default.Span(List.ofArray([Default.Id("compositionComplete")]));
            value1=jQuery("body").append(element.Dom);
            _=void value1;
           }
          else
           {
            _=null;
           }
          return _;
         });
         return scope.$on("$stateChangeSuccess",Runtime.Tupled(function(tupledArg1)
         {
          var toState;
          tupledArg1[0];
          toState=tupledArg1[1];
          tupledArg1[2];
          tupledArg1[3];
          tupledArg1[4];
          toState.data;
          return null;
         }));
        }))).DefineController({
         $:1
        },"HomeController",AngularExpression1.New(Services.Scope()).Resolve(function()
        {
         return null;
        })).DefineController({
         $:2
        },"AboutController",AngularExpression1.New(Services.Scope()).Resolve(function()
        {
         var chart;
         chart=jQuery("#chart");
         return chart.highcharts({
          title:{
           text:"Monthly Average Temperature",
           x:-20
          },
          subtitle:{
           text:"Source: WorldClimate.com",
           x:-20
          },
          xAxis:{
           categories:["Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec"]
          },
          yAxis:{
           title:{
            text:"Temperature (°C)"
           },
           plotLines:[{
            value:0,
            width:1,
            color:"#808080"
           }]
          },
          tooltip:{
           valueSuffix:"°C"
          },
          legend:{
           layout:"vertical",
           align:"right",
           verticalAlign:"middle",
           borderWidth:0
          },
          series:[{
           name:"Tokyo",
           data:[7,6.9,9.5,14.5,18.2,21.5,25.2,26.5,23.3,18.3,13.9,9.6]
          },{
           name:"New York",
           data:[-0.2,0.8,5.7,11.3,17,22,24.8,24.1,20.1,14.1,8.6,2.5]
          },{
           name:"Berlin",
           data:[-0.9,0.6,3.5,8.4,13.5,17,18.6,17.9,14.3,9,3.9,1]
          },{
           name:"London",
           data:[3.9,4.2,5.7,8.5,11.9,15.2,17,16.6,14.2,10.3,6.6,4.8]
          }]
         });
        })).DefineController({
         $:3
        },"MusicController",AngularExpression1.New(Services.CustomScope()).Resolve(function(scope)
        {
         var f,arg00,t;
         f=function()
         {
          var x,f1;
          x=AjaxRemotingProvider.Async("ellipsoid.org.Weatherwax.Web:0",[]);
          f1=function(_arg1)
          {
           var value;
           scope.songs=_arg1;
           value=scope.$apply();
           return Concurrency.Return(null);
          };
          return Concurrency.Bind(x,f1);
         };
         arg00=Concurrency.Delay(f);
         t={
          $:0
         };
         return Concurrency.Start(arg00,t);
        })).DefineController({
         $:4
        },"ErrorController",AngularExpression1.New(Services.Scope()).Resolve(function()
        {
         return null;
        }));
       })
      },
      AngularEntryPoint:Runtime.Class({
       get_Body:function()
       {
        var x,f;
        x=Operators.add(Default.Div(List.ofArray([Default.Attr().Class("angular-sitelet-root"),ClientDirectives.NgController("BaseController")])),List.ofArray([ClientDirectives.UIView(Runtime.New(T,{
         $:0
        }))]));
        f=function(el)
        {
         var value;
         value=angular.bootstrap(el.Dom,[Configuration.AppName()]);
         return;
        };
        Operators.OnAfterRender(f,x);
        return x;
       }
      }),
      AngularModules:{
       SiteletApp:Runtime.Field(function()
       {
        return Utilities["Module.Controllers"](Utilities["Module.States"](angular.module(Configuration.AppName(),[Dependencies.Router(),Dependencies.UIRouter()]).config(AngularConfiguration.UrlConfiguration()).config(AngularConfiguration.UIRouterConfiguration()),AngularRouter.StateConfiguration(),function(_arg1)
        {
         return AngularStates.AngularStateName(_arg1);
        },function(_arg1)
        {
         return AngularTemplates.TemplateRelativePath(_arg1);
        },AngularControllers.ControllerConfiguration()),AngularControllers.ControllerConfiguration());
       })
      },
      AngularRouter:{
       SI:function(url,template,controller)
       {
        return{
         Url:url,
         Template:template,
         Controller:controller,
         CustomData:{
          $:0
         }
        };
       },
       StateConfiguration:Runtime.Field(function()
       {
        var arg0,arg01,arg02,arg03;
        arg0={
         $:1,
         $0:{
          $:0
         }
        };
        arg01={
         $:1,
         $0:{
          $:1
         }
        };
        arg02={
         $:1,
         $0:{
          $:2
         }
        };
        arg03={
         $:1,
         $0:{
          $:3
         }
        };
        return StateConfiguration.New(function(_arg1)
        {
         return AngularStates.AngularStateName(_arg1);
        }).DefineState({
         $:0,
         $0:{
          $:0
         }
        },AngularRouter.SI({
         $:0
        },{
         $:0,
         $0:{
          $:0
         }
        },{
         $:0
        })).DefineState({
         $:0,
         $0:arg0
        },AngularRouter.SI({
         $:1,
         $0:"^/"
        },{
         $:0,
         $0:{
          $:1
         }
        },{
         $:1,
         $0:{
          $:1
         }
        })).DefineState({
         $:0,
         $0:arg01
        },AngularRouter.SI({
         $:1,
         $0:"^/about"
        },{
         $:0,
         $0:{
          $:2
         }
        },{
         $:1,
         $0:{
          $:2
         }
        })).DefineState({
         $:0,
         $0:arg02
        },AngularRouter.SI({
         $:1,
         $0:"^/music"
        },{
         $:0,
         $0:{
          $:3
         }
        },{
         $:1,
         $0:{
          $:3
         }
        })).DefineState({
         $:0,
         $0:arg03
        },AngularRouter.SI({
         $:1,
         $0:"^/error/{id}"
        },{
         $:1,
         $0:function(p)
         {
          return AngularRouter.errorTemplate(p);
         }
        },{
         $:1,
         $0:{
          $:4
         }
        })).When("","/").Otherwise1("/error/404");
       }),
       errorTemplate:function(p)
       {
        return"Template/"+PrintfHelpers.toSafe(AngularTemplates.TemplateRelativePath({
         $:4,
         $0:p.id
        }));
       }
      },
      AngularStates:{
       AngularStateName:function(_arg1)
       {
        var value,matcher;
        value=_arg1.$0;
        matcher=function(_arg2)
        {
         return _arg2.$==1?"about":_arg2.$==2?"music":_arg2.$==3?"error":"home";
        };
        return AngularStates.subState("master",value,matcher);
       },
       subState:function(name,value,matcher)
       {
        var _,s,_1;
        if(value.$==1)
         {
          s=value.$0;
          _1=matcher(s);
          _=PrintfHelpers.toSafe(name)+"."+PrintfHelpers.toSafe(_1);
         }
        else
         {
          _=name;
         }
        return _;
       }
      },
      AngularTemplates:{
       TemplateRelativePath:function(_arg1)
       {
        var _,x;
        if(_arg1.$==1)
         {
          _="Home";
         }
        else
         {
          if(_arg1.$==2)
           {
            _="About";
           }
          else
           {
            if(_arg1.$==3)
             {
              _="Music";
             }
            else
             {
              if(_arg1.$==4)
               {
                x=_arg1.$0;
                _="Error/"+Global.String(x);
               }
              else
               {
                _="Master";
               }
             }
           }
         }
        return _;
       }
      },
      Configuration:{
       AppName:Runtime.Field(function()
       {
        return"siteletApp";
       })
      }
     }
    }
   }
  }
 });
 Runtime.OnInit(function()
 {
  ellipsoid=Runtime.Safe(Global.ellipsoid);
  org=Runtime.Safe(ellipsoid.org);
  Weatherwax=Runtime.Safe(org.Weatherwax);
  Core=Runtime.Safe(Weatherwax.Core);
  AngularExpression1=Runtime.Safe(Core.AngularExpression1);
  Dependencies=Runtime.Safe(Core.Dependencies);
  Providers=Runtime.Safe(Dependencies.Providers);
  ControllerConfiguration=Runtime.Safe(Core.ControllerConfiguration);
  AngularExpression2=Runtime.Safe(Core.AngularExpression2);
  Services=Runtime.Safe(Dependencies.Services);
  jQuery=Runtime.Safe(Global.jQuery);
  WebSharper=Runtime.Safe(Global.IntelliFactory.WebSharper);
  Html=Runtime.Safe(WebSharper.Html);
  Client=Runtime.Safe(Html.Client);
  Default=Runtime.Safe(Client.Default);
  List=Runtime.Safe(WebSharper.List);
  Remoting=Runtime.Safe(WebSharper.Remoting);
  AjaxRemotingProvider=Runtime.Safe(Remoting.AjaxRemotingProvider);
  Concurrency=Runtime.Safe(WebSharper.Concurrency);
  Operators=Runtime.Safe(Client.Operators);
  ClientDirectives=Runtime.Safe(Core.ClientDirectives);
  T=Runtime.Safe(List.T);
  angular=Runtime.Safe(Global.angular);
  Web=Runtime.Safe(Weatherwax.Web);
  Configuration=Runtime.Safe(Web.Configuration);
  Utilities=Runtime.Safe(Core.Utilities);
  AngularConfiguration=Runtime.Safe(Web.AngularConfiguration);
  AngularRouter=Runtime.Safe(Web.AngularRouter);
  AngularStates=Runtime.Safe(Web.AngularStates);
  AngularTemplates=Runtime.Safe(Web.AngularTemplates);
  AngularControllers=Runtime.Safe(Web.AngularControllers);
  StateConfiguration=Runtime.Safe(Core.StateConfiguration);
  PrintfHelpers=Runtime.Safe(WebSharper.PrintfHelpers);
  return AngularModules=Runtime.Safe(Web.AngularModules);
 });
 Runtime.OnLoad(function()
 {
  Configuration.AppName();
  AngularRouter.StateConfiguration();
  AngularModules.SiteletApp();
  AngularControllers.ControllerConfiguration();
  AngularConfiguration.UrlConfiguration();
  AngularConfiguration.UIRouterConfiguration();
  return;
 });
}());
