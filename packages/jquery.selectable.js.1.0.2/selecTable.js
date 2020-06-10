//params
//---
/*
onSubSelect($changed)
Type:function
--Trigger when any sub checkbox changed.
--parameters
----$changed A jquery object representing  changed checkbox.
--
onAllSelect
Type:function
--Trigger when top chekbox selected.
onAllUnSelect
Type:function
--Trigger when top checkbox unselected.
*/
jQuery.fn.selecTable = function (param, attr) {
    this.each(function (idx, val) {
        var tagName = jQuery(val).prop('tagName');
        if (tagName != 'TABLE') {
            throw 'selecTable plugin does not support '+tagName+' element';
        }
    });

    var options = jQuery.extend({
        onTopSelect: function () { },
        onTopUnselect: function () { },
        onSubSelect: function () { },
    }, arguments[0] || {}, arguments[1] || {}, arguments[2] || {});

    if (typeof param == 'string') {
        if (typeof attr == 'undefined') { attr = 'id' }
        switch (param) {
            case 'getSelecteds':
                var selectedAttrs = [];
                this.each(function (idx, val) {

                    var tableId = idx + jQuery(val).attr('id');
                    var subs = jQuery('.' + tableId + 'selectableItem');
                    jQuery.each(subs, function (idx, value) {
                        if (jQuery(value).is(':checked')) {
                            selectedAttrs.push(jQuery(value).closest('tr').attr(attr));
                        }

                    });
                });
                return selectedAttrs;
            case 'getUnselecteds':
                var unselectedAttrs = [];
                this.each(function (idx, val) {
                    var tableId = idx + jQuery(val).attr('id');
                    var subs = jQuery('.' + tableId + 'selectableItem');
                    jQuery.each(subs, function (idx, value) {
                        if (!(jQuery(value).is(':checked'))) {
                            unselectedAttrs.push(jQuery(value).closest('tr').attr(attr));
                        }
                    });
                });
                return unselectedAttrs;
            default:
                throw "This command does not exist..!";
        }
    }
    return this.each(function (idx, val) {
        var $val = jQuery(val);
        var tableId = idx + $val.attr('id');
        var $thead = $val.find('thead');
        var $tbody = $val.find('tbody');
        var $tr = $tbody.find('tr');
        $thead.find('tr').prepend('<th class="text-center"><input type="checkbox" id="selecTableAll_' + tableId + '"/></th>')
        $tr.prepend('<td class="text-center"><input type="checkbox" class="' + tableId + 'selectableItem"/></td>')
        var $baseChekbox = jQuery('#selecTableAll_' + tableId);
        var $subCheckboxes = jQuery('.' + tableId + 'selectableItem');
        registerEvents();
        function registerEvents() {
            $baseChekbox.change(function () {
                if ($baseChekbox.is(':checked')) {
                    $subCheckboxes.prop('checked', true);
                    options.onTopSelect.call(this);
                }
                else {
                    $subCheckboxes.prop('checked', false);
                    options.onTopUnselect.call(this);
                }
            });
            $subCheckboxes.change(function () {
                var $self = jQuery(this);
                if (!($self.is(':checked'))) {
                    $baseChekbox.prop('checked', false);
                }
                else {
                    var allChecked = true;
                    jQuery.each($subCheckboxes, function (idx, val) {
                        if (!(jQuery(val)).is(':checked')) {
                            $baseChekbox.prop('checked', false);
                            allChecked = false;
                            return false;
                        }
                    });
                    if (allChecked) {
                        $baseChekbox.prop('checked', true);
                    } else {
                        $baseChekbox.prop('checked', false);
                    }
                }
                options.onSubSelect.call(this, $self);
            });
        }
    });


}