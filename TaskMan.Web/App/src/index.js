require("./scss/index.scss");
import $ from "jquery";
import 'babel-polyfill';
import Vue from "vue";
import Components from "./components";

require("./filters");

$(() => {
    $("a[href]").attr("href", "javascript:void(0)");
    const vue = new Vue({
        el: "#app",
        data: {
            
        },
        methods: {
            onError(e) {
                console.log(e);
            }
        },
        components: Components
    });

});
