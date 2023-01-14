mergeInto(LibraryManager.library, {

  Hello: function () {
    window.alert("Hello, world!");
  },

  OpenWindow: function(link)
  {
    var url = Pointer_stringify(link);
      document.onmouseup = function()
      {
        window.open(url);
        document.onmouseup = null;
      }
  },


  GetUserID: function(){

    function escape(s) { 
    return s.replace(/([.*+?\^$(){}|\[\]\/\\])/g, '\\$1'); 
    }

    var name1 = "userId";
    var match = document.cookie.match(RegExp('(?:^|;\\s*)' + escape(name1) + '=([^;]*)'));
    console.log("match " + match);
    console.log("match[1]" + match[1]);
    if(match)
    {
      var bufferSize = lengthBytesUTF8(match[1]) + 1;
      var buffer = _malloc(bufferSize);
      stringToUTF8(match[1], buffer, bufferSize);
      return buffer;
    }
    else
    {
      return null;
    }

},
  



});