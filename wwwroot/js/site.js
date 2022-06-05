// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var start = 0;
var end = 6;
$(".blog-item").slice(start, end).show()
$(".blog-Load").on("click", function () {
    start = start + 6
    end = end + 6;
    $(".blog-item").slice(start, end).show()
    if ($(".blog-item:hidden").length == 0) {
        $(".blog-Load").fadeOut("slow")
    }
})
