import TypeAhead from "type-ahead";
import Vue from "vue";
const template = require("./index.html");

const defaultComponent = Vue.component({
    template: template,
    props: {
        inputIsReadOnly: Boolean,
        inputValue: null,
        inputType: String,
        inputName: String,
        inputHiddenValue: null,
        inputHiddenName: String,
        inputHiddenVisible: Boolean,
        inputDataSource: Object,
        inputDataSourceTextId:String,
        inputDataSourceValueId:String
    },
    data() {
        return {
            typeAhead: null,
            input: {
                changed: false,
                oldValue: this.inputValue,
                type: this.inputType,
                readOnly: this.inputIsReadOnly,
                value: this.inputValue,
                name: this.inputName,
                dataSource: this.dataSource
            },
            hiddenInput: {
                changed: false,
                visible: this.inputHiddenVisible,
                oldValue: this.inputHiddenValue,
                value: this.inputHiddenValue,
                name: this.inputHiddenName
            }
        };
    },
    watch: {
        inputDataSource(newValue) {
            this.input.dataSource = newValue;
        },
        inputIsReadOnly(newValue) {
            this.input.readOnly = newValue;
        },
        inputValue(newValue) {
            this.input.value = newValue;
        },
        inputType(newValue) {
            this.input.type = newValue;
        },
        inputName(newValue) {
            this.input.name = newValue;
        },
        inputHiddenValue(newValue) {
            this.hiddenInput.value = newValue;
        },
        inputHiddenName(newValue) {
            this.hiddenInput.name = newValue;
        },
        inputHiddenVisible(newValue) {
            this.hiddenInput.visible = newValue;
        }
    },
    methods: {
        bindDataSource($el) {
            if(!this.input.dataSource 
                || !this.input.dataSource.length)
                return;

            const options = {
                callback(newValue) {
                   this.$emit("value:changed", newValue);
                }
            };
            this.typeAhead = new TypeAhead($el, this.input.dataSource, options);
            const context = this;
            if(this.inputDataSourceTextId)
                this.typeAhead.getItemValue((item) => item[context.inputDataSourceTextId]);
        },
        hasInputChanged(target) {
            return target.oldValue !== target.value;
        },
        inputChange(e) {
            this.input.value = e.target.value;
            this.input.changed = this.hasInputChanged(this.input);
        },
        hiddenInputChange() {
            this.hiddenInput.value = e.target.value;
            this.hiddenInput.changed = this.hasInputChanged(this.hiddenInput);
        }
    },
    mounted() {
        if(!this.input.dataSource 
            || this.input.dataSource.length 
            || !this.$el)
            return;

        const $inputEl = this.$el.querySelector("input[type='text']");
        this.bindDataSource($inputEl);
    }
});

export default defaultComponent;