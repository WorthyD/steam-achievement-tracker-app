var Cookies = (function (d, w) {
    return {
        Set: function (cookieName, cookieValue, daysExperation) {
            var expires = '',
                 xpDate = new Date();
            if (daysExperation) {
                xpDate.setTime(xpDate.getTime() + (daysExperation * 24 * 60 * 60 * 1000));
                expires = '; expires=' + xpDate.toUTCString();
            }
            d.cookie = cookieName + '=' + cookieValue + expires + '; path=/';
        },
        Get: function (cookieName) {
            var results = d.cookie.match(cookieName + '=(.*?)(;|$)');
            if (results) {
                return (w.unescape(results[1]));
            }
            return null;
        },
        Delete: function (cookieName) {
            this.Set(cookieName, '', -1);
        }
    };
})(document, window);