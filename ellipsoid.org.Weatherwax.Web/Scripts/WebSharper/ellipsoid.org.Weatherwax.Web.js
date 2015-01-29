(function()
{
 var Global=this,Runtime=this.IntelliFactory.Runtime,ellipsoid,org,Weatherwax,Core,AngularExpression1,Dependencies,Providers,ControllerConfiguration,AngularExpression2,Services,jQuery,WebSharper,Html,Default,List,Remoting,Concurrency,Operators,ClientDirectives,T,angular,Web,Configuration,Utilities,AngularConfiguration,AngularRouter,AngularControllers,Unchecked,Seq,Operators1,AngularTemplates,AngularModules;
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
         urlMatcherFactory.caseInsensitive(true);
         urlMatcherFactory.strictMode(false);
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
         return tupledArg[1].$on("$viewContentLoaded",function()
         {
          var element;
          if(jQuery("#compositionComplete").length===0)
           {
            element=Default.Span(List.ofArray([Default.Id("compositionComplete")]));
            jQuery("body").append(element.Body);
            return;
           }
          else
           {
            return null;
           }
         });
        }))).DefineController({
         $:1
        },"HomeController",AngularExpression1.New(Services.Scope()).Resolve(function()
        {
         return null;
        })).DefineController({
         $:2
        },"AboutController",AngularExpression1.New(Services.Scope()).Resolve(function()
        {
         var chart,returnVal,returnVal1,returnVal2,returnVal3,returnVal4,returnVal5;
         chart=jQuery("#chart");
         returnVal={};
         returnVal.text="Monthly Average Temperature";
         returnVal.x=-20;
         returnVal1={};
         returnVal1.text="Source: WorldClimate.com";
         returnVal1.x=-20;
         returnVal2={};
         returnVal2.categories=["Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec"];
         returnVal3={};
         returnVal3.title={
          text:"Temperature (°C)"
         };
         returnVal3.plotLines=[{
          value:0,
          width:1,
          color:"#808080"
         }];
         returnVal4={};
         returnVal4.valueSuffix="°C";
         returnVal5={};
         returnVal5.layout="vertical";
         returnVal5.align="right";
         returnVal5.verticalAlign="middle";
         returnVal5.borderWidth=0;
         return chart.highcharts({
          title:returnVal,
          subtitle:returnVal1,
          xAxis:returnVal2,
          yAxis:returnVal3,
          tooltip:returnVal4,
          legend:returnVal5,
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
          x=Remoting.Async("ellipsoid.org.Weatherwax.Web:0",[]);
          f1=function(_arg1)
          {
           scope.songs=_arg1;
           scope.$apply();
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
        var x;
        x=Operators.add(Default.Div(List.ofArray([Default.Attr().Class("angular-sitelet-root"),ClientDirectives.NgController("BaseController")])),List.ofArray([ClientDirectives.UIView(Runtime.New(T,{
         $:0
        }))]));
        Operators.OnAfterRender(function(el)
        {
         angular.bootstrap(el.Body,[Configuration.AppName()]);
        },x);
        return x;
       }
      }),
      AngularModules:{
       SiteletApp:Runtime.Field(function()
       {
        return Utilities["Module.Controllers"](angular.module(Configuration.AppName(),[Dependencies.Router(),Dependencies.UIRouter()]).config(AngularConfiguration.UrlConfiguration()).config(AngularConfiguration.UIRouterConfiguration()).config(AngularRouter.RouteConfiguration()),AngularControllers.ControllerConfiguration());
       })
      },
      AngularRouter:{
       ControllerName:function(controller)
       {
        var p,l,matchValue;
        p=function(c)
        {
         return Unchecked.Equals(c.Controller,controller);
        };
        l=AngularControllers.ControllerConfiguration().get_Controllers();
        matchValue=Seq.tryFind(p,l);
        return matchValue.$==0?Operators1.FailWith("Controller not defined in ControllerConfiguration"):matchValue.$0.Name;
       },
       RouteConfiguration:Runtime.Field(function()
       {
        return AngularExpression2.New(Providers.State(),Providers.UrlRouter()).Resolve(Runtime.Tupled(function(tupledArg)
        {
         var stateProvider,urlRouterProvider;
         stateProvider=tupledArg[0];
         urlRouterProvider=tupledArg[1];
         stateProvider.state("master",{
          "abstract":true,
          templateUrl:AngularRouter.TemplateUrl({
           $:0
          })
         }).state("master.home",{
          url:"^/",
          templateUrl:AngularRouter.TemplateUrl({
           $:1
          }),
          controller:AngularRouter.ControllerName({
           $:1
          })
         }).state("master.about",{
          url:"^/about",
          templateUrl:AngularRouter.TemplateUrl({
           $:2
          }),
          controller:AngularRouter.ControllerName({
           $:2
          })
         }).state("master.music",{
          url:"^/music",
          templateUrl:AngularRouter.TemplateUrl({
           $:3
          }),
          controller:AngularRouter.ControllerName({
           $:3
          })
         }).state("master.error",{
          url:"^/error/{id}",
          templateUrl:function(p)
          {
           return AngularRouter.TemplateUrl({
            $:4,
            $0:p.id
           });
          },
          controller:AngularRouter.ControllerName({
           $:4
          })
         });
         urlRouterProvider.when("","/");
         urlRouterProvider.otherwise("/error/404");
         return;
        }));
       }),
       TemplateUrl:function(t)
       {
        return"Template/"+AngularTemplates.TemplateRelativePath(t);
       }
      },
      AngularTemplates:{
       TemplateRelativePath:function(_arg1)
       {
        return _arg1.$==1?"Home":_arg1.$==2?"About":_arg1.$==3?"Music":_arg1.$==4?"Error/"+Global.String(_arg1.$0):"Master";
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
  Default=Runtime.Safe(Html.Default);
  List=Runtime.Safe(WebSharper.List);
  Remoting=Runtime.Safe(WebSharper.Remoting);
  Concurrency=Runtime.Safe(WebSharper.Concurrency);
  Operators=Runtime.Safe(Html.Operators);
  ClientDirectives=Runtime.Safe(Core.ClientDirectives);
  T=Runtime.Safe(List.T);
  angular=Runtime.Safe(Global.angular);
  Web=Runtime.Safe(Weatherwax.Web);
  Configuration=Runtime.Safe(Web.Configuration);
  Utilities=Runtime.Safe(Core.Utilities);
  AngularConfiguration=Runtime.Safe(Web.AngularConfiguration);
  AngularRouter=Runtime.Safe(Web.AngularRouter);
  AngularControllers=Runtime.Safe(Web.AngularControllers);
  Unchecked=Runtime.Safe(WebSharper.Unchecked);
  Seq=Runtime.Safe(WebSharper.Seq);
  Operators1=Runtime.Safe(WebSharper.Operators);
  AngularTemplates=Runtime.Safe(Web.AngularTemplates);
  return AngularModules=Runtime.Safe(Web.AngularModules);
 });
 Runtime.OnLoad(function()
 {
  Configuration.AppName();
  AngularRouter.RouteConfiguration();
  AngularModules.SiteletApp();
  AngularControllers.ControllerConfiguration();
  AngularConfiguration.UrlConfiguration();
  AngularConfiguration.UIRouterConfiguration();
  return;
 });
}());
