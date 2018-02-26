$(function() {

    var navBar = $("nav");
    var footer = $("footer");

    //$("section").first().css("min-height", ( $(window).height() - navBar.height() ) - (footer.height()) );

    console.log($("section").first().height());

    $("section").first().css("min-height", ($(window).height() - navBar.outerHeight(true)) - footer.outerHeight(true) );

    console.log($(window).height());
    console.log($("section").first().height());
})