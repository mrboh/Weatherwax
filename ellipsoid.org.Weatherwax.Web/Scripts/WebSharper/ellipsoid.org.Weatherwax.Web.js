(function()
{
 var Global=this,Runtime=this.IntelliFactory.Runtime,ellipsoid,org,Weatherwax,Core,AngularExpression1,Dependencies,Providers,WebSharper,Html,Client,Operators,Default,List,ClientDirectives,T,Remoting,AjaxRemotingProvider,Utilities,angular,Web,Configuration,AngularConfiguration,Controllers,BaseController,HomeController,AboutController,MusicController,ErrorController,Concurrency,WeatherwaxController,Services,jQuery,AngularExpression2,Events;
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
      AngularEntryPoint:Runtime.Class({
       get_Body:function()
       {
        var x,_this,f;
        _this=Default.Attr();
        x=Operators.add(Default.Div(List.ofArray([_this.NewAttr("id","angular-sitelet-root"),ClientDirectives.NgController("BaseController")])),List.ofArray([ClientDirectives.UIView(Runtime.New(T,{
         $:0
        }))]));
        f=function(el)
        {
         var f1,arg00,t;
         f1=function()
         {
          var x1,f2;
          x1=AjaxRemotingProvider.Async("ellipsoid.org.Weatherwax.Core:0",[]);
          f2=function(_arg1)
          {
           var value,value1;
           value=Utilities["Module.Controllers"](Utilities["Module.States"](angular.module(Configuration.AppName(),[Dependencies.Router(),Dependencies.UIRouter()]).config(AngularConfiguration.UrlConfiguration()).config(AngularConfiguration.UIRouterConfiguration()),_arg1,{
            $:1,
            $0:"/error/404"
           },{
            $:1,
            $0:[{
             UrlIn:"",
             UrlOut:"/"
            }]
           }),List.ofArray([BaseController.New(),HomeController.New(),AboutController.New(),MusicController.New(),ErrorController.New()]));
           value1=angular.bootstrap(el.Dom,[Configuration.AppName()]);
           return Concurrency.Return(null);
          };
          return Concurrency.Bind(x1,f2);
         };
         arg00=Concurrency.Delay(f1);
         t={
          $:0
         };
         return Concurrency.Start(arg00,t);
        };
        Operators.OnAfterRender(f,x);
        return x;
       }
      }),
      Configuration:{
       AppName:Runtime.Field(function()
       {
        return"siteletApp";
       })
      },
      Controllers:{
       AboutController:Runtime.Class({
        get_Controller:function()
        {
         return{
          $:2
         };
        },
        get_Implementation:function()
        {
         return AngularExpression1.New(Services.Scope()).Resolve(function()
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
         });
        },
        get_Name:function()
        {
         return this.FromSourceFilename("AboutController.fs");
        }
       },{
        New:function()
        {
         return Runtime.New(this,WeatherwaxController.New());
        }
       }),
       BaseController:Runtime.Class({
        get_Controller:function()
        {
         return{
          $:0
         };
        },
        get_Implementation:function()
        {
         return AngularExpression2.New(Services.Scope(),Services.RootScope()).Resolve(Runtime.Tupled(function(tupledArg)
         {
          var scope,rootScope,value;
          scope=tupledArg[0];
          rootScope=tupledArg[1];
          value=rootScope.$on(Events.ViewContentLoaded(),function()
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
          return scope.$on(Events.StateChangeSuccess(),Runtime.Tupled(function(tupledArg1)
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
         }));
        },
        get_Name:function()
        {
         return this.FromSourceFilename("BaseController.fs");
        }
       },{
        New:function()
        {
         return Runtime.New(this,WeatherwaxController.New());
        }
       }),
       ErrorController:Runtime.Class({
        get_Controller:function()
        {
         return{
          $:4
         };
        },
        get_Implementation:function()
        {
         return AngularExpression1.New(Services.Scope()).Resolve(function()
         {
          return null;
         });
        },
        get_Name:function()
        {
         return this.FromSourceFilename("ErrorController.fs");
        }
       },{
        New:function()
        {
         return Runtime.New(this,WeatherwaxController.New());
        }
       }),
       HomeController:Runtime.Class({
        get_Controller:function()
        {
         return{
          $:1
         };
        },
        get_Implementation:function()
        {
         return AngularExpression1.New(Services.Scope()).Resolve(function()
         {
          return null;
         });
        },
        get_Name:function()
        {
         return this.FromSourceFilename("HomeController.fs");
        }
       },{
        New:function()
        {
         return Runtime.New(this,WeatherwaxController.New());
        }
       }),
       MusicController:Runtime.Class({
        get_Controller:function()
        {
         return{
          $:3
         };
        },
        get_Implementation:function()
        {
         return AngularExpression1.New(Services.CustomScope()).Resolve(function(scope)
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
         });
        },
        get_Name:function()
        {
         return this.FromSourceFilename("MusicController.fs");
        }
       },{
        New:function()
        {
         return Runtime.New(this,WeatherwaxController.New());
        }
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
  WebSharper=Runtime.Safe(Global.IntelliFactory.WebSharper);
  Html=Runtime.Safe(WebSharper.Html);
  Client=Runtime.Safe(Html.Client);
  Operators=Runtime.Safe(Client.Operators);
  Default=Runtime.Safe(Client.Default);
  List=Runtime.Safe(WebSharper.List);
  ClientDirectives=Runtime.Safe(Core.ClientDirectives);
  T=Runtime.Safe(List.T);
  Remoting=Runtime.Safe(WebSharper.Remoting);
  AjaxRemotingProvider=Runtime.Safe(Remoting.AjaxRemotingProvider);
  Utilities=Runtime.Safe(Core.Utilities);
  angular=Runtime.Safe(Global.angular);
  Web=Runtime.Safe(Weatherwax.Web);
  Configuration=Runtime.Safe(Web.Configuration);
  AngularConfiguration=Runtime.Safe(Web.AngularConfiguration);
  Controllers=Runtime.Safe(Web.Controllers);
  BaseController=Runtime.Safe(Controllers.BaseController);
  HomeController=Runtime.Safe(Controllers.HomeController);
  AboutController=Runtime.Safe(Controllers.AboutController);
  MusicController=Runtime.Safe(Controllers.MusicController);
  ErrorController=Runtime.Safe(Controllers.ErrorController);
  Concurrency=Runtime.Safe(WebSharper.Concurrency);
  WeatherwaxController=Runtime.Safe(Core.WeatherwaxController);
  Services=Runtime.Safe(Dependencies.Services);
  jQuery=Runtime.Safe(Global.jQuery);
  AngularExpression2=Runtime.Safe(Core.AngularExpression2);
  return Events=Runtime.Safe(Dependencies.Events);
 });
 Runtime.OnLoad(function()
 {
  Runtime.Inherit(AboutController,WeatherwaxController);
  Runtime.Inherit(BaseController,WeatherwaxController);
  Runtime.Inherit(ErrorController,WeatherwaxController);
  Runtime.Inherit(HomeController,WeatherwaxController);
  Runtime.Inherit(MusicController,WeatherwaxController);
  Configuration.AppName();
  AngularConfiguration.UrlConfiguration();
  AngularConfiguration.UIRouterConfiguration();
  return;
 });
}());
