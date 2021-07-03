let selected = [];
$(".filter-button").click(function filter_items () {
    if (selected.includes(this.id)===true) {
        let index = selected.indexOf(this.id);
        if (index > -1) {
            selected.splice(index, 1);
            this.classList.remove("active");
            this.classList.add("not-active");
        }} else {
        selected.push($(this).attr('data-filter'));
        this.classList.remove("not-active");
        this.classList.add("active");
    }
    if (selected.length > 0) {
        $(".filter-item").not(selected).hide();
        for (var i = 0; i < selected.length; i++) {
            $('.filter-item').filter('.' + selected[i]).show('500');
        }
    }else {$('.filter-item').show('500');}
});