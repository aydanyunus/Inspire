$('.grid').isotope({
    itemSelector: '.grid-item',
    layoutMode: 'fitRows'
  });           
  $('.isotop-filters a').click(function(){
    $('.isotop-filters a').removeClass('active');
    $(this).addClass('active');

    var selector = $(this).attr('data-filter');
    $('.grid').isotope({
      filter: selector
    });
    return false;
    
  })   