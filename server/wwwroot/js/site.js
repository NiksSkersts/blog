/*DECLARE*/
const uri = 'api/Email';
var selected = [];
/*FUNCTIONS*/
async function addItem() {
    const data = document.getElementById('input-email').value;
    const response = await fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            "IdEmail": 0,
            "Email1": data
        })
    });
    return response.json().then(document.getElementById('input-email').value = "Paldies!");
}
// shows and hides filtered items in Poems
$(".poem-filter-button").click(function () {
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
                $(".poem-filter-item").not(selected).hide();
                for (var i = 0; i < selected.length; i++) {
                    $('.poem-filter-item').filter('.' + selected[i]).show('500');
                }
            }else {$('.poem-filter-item').show('500');}
    });
// shows and hides filtered items in Pictures
$(".filter-button").click(function () {
    let value = $(this).attr('data-filter');
    if (value === "visi") {
        $('.filter-item').show('1000');
    } else {
        $(".filter-item").not('.' + value).hide('3000');
        $('.filter-item').filter('.' + value).show('3000');
    }
});
// changes active class on filter buttons
$('.filter-button').click(function () {
    $(this).siblings().removeClass('is-active');
    $(this).addClass('is-active');
});
window.onresize = function() {
    if (window.innerHeight >= 650) { $('.product-filters').removeClass('close-menu').addClass('open-menu'); $('.categories-menu').show(500);}
}
if ($(window).width() < 650) {
    $('.mailing-container').removeClass('tiny').addClass('full');
}else {
    $('.mailing-container').removeClass('full').addClass('tiny');
}
$('.filter-header').click(function (){
    if ($(window).width() < 650) {
        if ($('.product-filters').hasClass('open-menu')){
            $('.categories-menu').hide(200);
            $('.product-filters').removeClass('open-menu').addClass('close-menu');
        }else{
            $('.categories-menu').show(500);
            $('.product-filters').removeClass('close-menu').addClass('open-menu');
        }
    }
})




