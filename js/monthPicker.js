Ext.define('Roc.component.MonthPicker', {
    extend: 'Ext.picker.Date',
    alias: 'widget.monthpicker',

    onOkClick: function(picker, value) {
        var me = this,
            month = value[0],
            year = value[1],
            date = new Date(year, month, me.getActive().getDate());

        if (date.getMonth() !== month) {
            // 'fix' the JS rolling date conversion if needed
            date = Ext.Date.getLastDateOfMonth(new Date(year, month, 1));
        }
        me.setValue(date);
        me.hideMonthPicker();

        var handler = me.handler;

        if (!me.disabled) {
            me.doCancelFocus = me.focusOnSelect === false;
            delete me.doCancelFocus;
            me.fireEvent('select', me, me.value);
            if (handler) {
                handler.call(me.scope || me, me, me.value);
            }
            // event handling is turned off on hide
            // when we are using the picker in a field
            // therefore onSelect comes AFTER the select
            // event.
            me.onSelect();
        }
    }


})；
// Ext.define('Ext.ux.MonthPickerPlugin', {
//     alias: 'plugin.monthPickerPlugin',
//     picker: null,
//     oldDateDefaults: null,

//     init: function(pk) {
//         this.picker = pk;
//         this.picker.onTriggerClick = this.picker.onTriggerClick.createSequence(this.onClick);
//         this.picker.getValue = this.picker.getValue.createInterceptor(this.setDefaultMonthDay).createSequence(this.restoreDefaultMonthDay);
//         this.picker.beforeBlur = this.picker.beforeBlur.createInterceptor(this.setDefaultMonthDay).createSequence(this.restoreDefaultMonthDay);
//     },

//     setDefaultMonthDay: function() {
//         this.oldDateDefaults = Date.defaults.d;
//         Date.defaults.d = 1;
//         return true;
//     },

//     restoreDefaultMonthDay: function(ret) {
//         Date.defaults.d = this.oldDateDefaults;
//         return ret;
//     },

//     onClick: function(e, el, opt) {
//         var p = this.picker.menu.picker;
//         p.activeDate = p.activeDate.getFirstDateOfMonth();
//         if (p.value) {
//             p.value = p.value.getFirstDateOfMonth();
//         }

//         p.showMonthPicker();

//         if (!p.disabled) {
//             p.monthPicker.stopFx();
//             p.monthPicker.show();

//             p.mun(p.monthPicker, 'click', p.onMonthClick, p);
//             p.mun(p.monthPicker, 'dblclick', p.onMonthDblClick, p);
//             p.onMonthClick = p.onMonthClick.createSequence(this.pickerClick);
//             p.onMonthDblClick = p.onMonthDblClick.createSequence(this.pickerDblclick);
//             p.mon(p.monthPicker, 'click', p.onMonthClick, p);
//             p.mon(p.monthPicker, 'dblclick', p.onMonthDblClick, p);
//         }
//     },

//     pickerClick: function(e, t) {
//         var el = new Ext.Element(t);
//         if (el.is('button.x-date-mp-cancel')) {
//             this.picker.menu.hide();
//         } else if (el.is('button.x-date-mp-ok')) {
//             var p = this.picker.menu.picker;
//             p.setValue(p.activeDate);
//             p.fireEvent('select', p, p.value);
//         }
//     },

//     pickerDblclick: function(e, t) {
//         var el = new Ext.Element(t);
//         if (el.parent() && (el.parent().is('td.x-date-mp-month') || el.parent().is('td.x-date-mp-year'))) {

//             var p = this.picker.menu.picker;
//             p.setValue(p.activeDate);
//             p.fireEvent('select', p, p.value);
//         }
//     }
// });

// Ext.ux.MonthPickerPlugin = function() {
//     var picker;
//     var oldDateDefaults;

//     this.init = function(pk) {
//         picker = pk;
//         picker.onTriggerClick = picker.onTriggerClick.createSequence(onClick);
//         picker.getValue = picker.getValue.createInterceptor(setDefaultMonthDay).createSequence(restoreDefaultMonthDay);
//         picker.beforeBlur = picker.beforeBlur.createInterceptor(setDefaultMonthDay).createSequence(restoreDefaultMonthDay);
//     };

//     function setDefaultMonthDay() {
//         oldDateDefaults = Date.defaults.d;
//         Date.defaults.d = 1;
//         return true;
//     }

//     function restoreDefaultMonthDay(ret) {
//         Date.defaults.d = oldDateDefaults;
//         return ret;
//     }

//     function onClick(e, el, opt) {
//         var p = picker.menu.picker;
//         p.activeDate = p.activeDate.getFirstDateOfMonth();
//         if (p.value) {
//             p.value = p.value.getFirstDateOfMonth();
//         }

//         p.showMonthPicker();

//         if (!p.disabled) {
//             p.monthPicker.stopFx();
//             p.monthPicker.show();

//             p.mun(p.monthPicker, 'click', p.onMonthClick, p);
//             p.mun(p.monthPicker, 'dblclick', p.onMonthDblClick, p);
//             p.onMonthClick = p.onMonthClick.createSequence(pickerClick);
//             p.onMonthDblClick = p.onMonthDblClick.createSequence(pickerDblclick);
//             p.mon(p.monthPicker, 'click', p.onMonthClick, p);
//             p.mon(p.monthPicker, 'dblclick', p.onMonthDblClick, p);
//         }
//     }

//     function pickerClick(e, t) {
//         var el = new Ext.Element(t);
//         if (el.is('button.x-date-mp-cancel')) {
//             picker.menu.hide();
//         } else if (el.is('button.x-date-mp-ok')) {
//             var p = picker.menu.picker;
//             p.setValue(p.activeDate);
//             p.fireEvent('select', p, p.value);
//         }
//     }

//     function pickerDblclick(e, t) {
//         var el = new Ext.Element(t);
//         if (el.parent() && (el.parent().is('td.x-date-mp-month') || el.parent().is('td.x-date-mp-year'))) {

//             var p = picker.menu.picker;
//             p.setValue(p.activeDate);
//             p.fireEvent('select', p, p.value);
//         }
//     }
// };

// Ext.preg('monthPickerPlugin', Ext.ux.MonthPickerPlugin);