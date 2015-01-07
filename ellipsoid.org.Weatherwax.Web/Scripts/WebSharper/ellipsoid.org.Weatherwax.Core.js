(function()
{
 var Global=this,Runtime=this.IntelliFactory.Runtime,WebSharper,Html,Default;
 Runtime.Define(Global,{
  ellipsoid:{
   org:{
    Weatherwax:{
     Core:{
      ClientDirectives:{
       NgController:function(x)
       {
        return Default.Attr().NewAttr("ng-controller",x);
       },
       NgRepeat:function(x)
       {
        return Default.Attr().NewAttr("ng-repeat",x);
       },
       NgView:function(x)
       {
        return Default.Tags().NewTag("ng-view",x);
       },
       SRef:function(x)
       {
        return Default.Attr().NewAttr("ui-sref",x);
       },
       UIView:function(x)
       {
        return Default.Tags().NewTag("ui-view",x);
       }
      }
     }
    }
   }
  }
 });
 Runtime.OnInit(function()
 {
  WebSharper=Runtime.Safe(Global.IntelliFactory.WebSharper);
  Html=Runtime.Safe(WebSharper.Html);
  return Default=Runtime.Safe(Html.Default);
 });
 Runtime.OnLoad(function()
 {
  return;
 });
}());
