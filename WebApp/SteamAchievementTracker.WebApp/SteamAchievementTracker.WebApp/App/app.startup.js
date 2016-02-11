/*jshint unused: false */
/*exported letsGetStarted 
 *
 *  
 */
/*jshint undef: false */
//function load() {
//    // remove the initial loading screen
//    var uncloaks = document.querySelectorAll(".uncloak");
//    for (var i = 0; i < uncloaks.length; i++) {
//        uncloaks[i].style.display = "none";
//    }

//    angular.bootstrap(document, ["app"]);
//}

//var retry = 1, maxRetries = 10;
//var interval = setInterval(function() {
//    if (letsGetStarted) {
//        console.log("cueme is ready; loading the app");
//        clearInterval(interval);
//        load();
//    } else {
//        console.log("cueme_ready - retry [" + retry + "]");
//        if (retry <= maxRetries) {
//            retry++;
//        } else {
//            clearInterval(interval);
//            console.log("exceeded maximum retries waiting for cueme to be ready.  exiting");
//            window.history.back();
//        }
//    }
//}, 500);