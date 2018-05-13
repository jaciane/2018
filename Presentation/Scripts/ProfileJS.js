$('#multi-select-custom').multiSelect({
    selectableOptgroup: true,
    keepOrder: true,
});
$('#ms-multi-select-custom').css("width", "100%");
$('.ms-optgroup-label').each(function (index, el) {
    $(el).addClass('font-green-meadow bold')
});