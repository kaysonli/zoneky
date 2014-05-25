(function() {

	Ext.onReady(function(argument) {
		var store = Ext.create('Ext.data.JsonStore', {
			fields: ['name', 'data1', 'data2', 'data3', 'data4', 'data5'],
			data: [{
				'name': 'metric one',
				'data1': 10,
				'data2': 12,
				'data3': 14,
				'data4': 8,
				'data5': 13
			}, {
				'name': 'metric two',
				'data1': 7,
				'data2': 8,
				'data3': 16,
				'data4': 10,
				'data5': 3
			}, {
				'name': 'metric three',
				'data1': 5,
				'data2': 2,
				'data3': 14,
				'data4': 12,
				'data5': 7
			}, {
				'name': 'metric four',
				'data1': 2,
				'data2': 14,
				'data3': 6,
				'data4': 1,
				'data5': 23
			}, {
				'name': 'metric five',
				'data1': 4,
				'data2': 4,
				'data3': 36,
				'data4': 13,
				'data5': 33
			}]
		});

		Ext.create('Ext.chart.Chart', {
			renderTo: "myChart",
			width: 500,
			height: 300,
			animate: true,
			store: store,
			axes: [{
				type: 'Numeric',
				position: 'left',
				fields: ['data1', 'data2'],
				label: {
					renderer: Ext.util.Format.numberRenderer('0,0')
				},
				title: 'Sample Values',
				grid: true,
				minimum: 0
			}, {
				type: 'Category',
				position: 'bottom',
				fields: ['name'],
				title: 'Sample Metrics'
			}],
			series: [{
				type: 'line',
				highlight: {
					size: 7,
					radius: 7
				},
				listeners: {
					itemclick: function(item) {
						console.log('line item clicked');
					},
					itemmouseover: function(item) {
						console.log('line item mouseover');
						var me = this;
						// setTimeout(function(){
						// 	//me.showTip(item);
						// }, me.tips.showDelay);
						return false;
					},
					itemmouseout: function(item) {
						var me = this;
						// setTimeout(function(){
						// 	//me.hideTip(item);
						// }, me.tip.hideDelay);
						// return false;
					}
				},
				tips: {
					width: 200,
					height: 150,
					showDelay: 3000,
					hideDelay: 3000,
					target: null,
					renderer: function(item) {
						this.setTitle('data1: ' + item.get('data1'));
					}
				},
				axis: 'left',
				xField: 'name',
				yField: 'data1',
				markerConfig: {
					type: 'cross',
					size: 4,
					radius: 4,
					'stroke-width': 0
				}
			}, {
				type: 'line',
				highlight: {
					size: 7,
					radius: 7
				},
				axis: 'left',
				fill: true,
				xField: 'data1',
				yField: 'data2',
				markerConfig: {
					type: 'circle',
					size: 4,
					radius: 4,
					'stroke-width': 0
				}
			}]
		});
		Ext.select('#block').on({
			'mouseover': function() {
				console.log('mouseover');
			},
			'mouseout': function() {
				console.log('mouseout');
			},
			'mousemove': function() {
				console.log('mousemove');
			}
		});

		Ext.override(Ext.picker.Date, {
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

				if (!me.pickerField.yearMonthOnly) {
					return;
				}

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
			},

			onCancelClick: function() {
				// update the selected value, also triggers a focus
				this.selectedUpdate(this.activeDate);
				this.hideMonthPicker();
				this.hide();
			}
		});

		Ext.create('Ext.form.Panel', {
			renderTo: 'datePicker',
			width: 300,
			bodyPadding: 10,
			title: 'Dates',
			items: [{
				xtype: 'datefield',
				anchor: '100%',
				showToday: false,
				yearMonthOnly: true,
				listeners: {
					expand: function(date, eOpts) {
						date.picker.showMonthPicker();
					}
				},
				fieldLabel: 'From',
				// plugins: ['monthPickerPlugin'],
				name: 'from_date',
				maxValue: new Date() // limited to the current date or prior
			}, {
				xtype: 'datefield',
				anchor: '100%',
				fieldLabel: 'To',
				name: 'to_date',
				value: new Date() // defaults to today
			}]
		});
	});


})();

$(function() {
	$("#btnDownload").click(function() {
		$.ajax({
			url: 'http://table.finance.yahoo.com/table.csv?s=000001.ss',
			dataType : "jsonp",
			jsonpCallback:"jsonpCallback",
			success: function(data) {
				console.log(data);
			}
		})
	});

	function jsonpCallback(data){
		console.log(data);
	}
});