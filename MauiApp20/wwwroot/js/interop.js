// Slick Slider başlatma
window.initSlick = function ( selector, options ) {
 try {
  if ( typeof $ !== 'undefined' && typeof $.fn.slick !== 'undefined' ) {
   var $element = $( selector );
   if ( $element.length ) {
    // Eğer zaten slick varsa önce yok et
    if ( $element.hasClass( 'slick-initialized' ) ) {
     $element.slick( 'unslick' );
    }
    $element.slick( options );
   }
  }
 } catch ( error ) {
  console.error( 'Slick initialization error:', error );
 }
};

// Slick Slider yok etme
window.destroySlick = function ( selector ) {
 try {
  if ( typeof $ !== 'undefined' && typeof $.fn.slick !== 'undefined' ) {
   var $element = $( selector );
   if ( $element.length && $element.hasClass( 'slick-initialized' ) ) {
    $element.slick( 'unslick' );
   }
  }
 } catch ( error ) {
  console.error( 'Slick destroy error:', error );
 }
};

// Timer başlatma
window.initTimer = function ( selector, targetDate ) {
 try {
  var countDownDate = new Date( targetDate ).getTime();

  var x = setInterval( function () {
   var now = new Date().getTime();
   var distance = countDownDate - now;

   var hours = Math.floor( ( distance % ( 1000 * 60 * 60 * 24 ) ) / ( 1000 * 60 * 60 ) );
   var minutes = Math.floor( ( distance % ( 1000 * 60 * 60 ) ) / ( 1000 * 60 ) );
   var seconds = Math.floor( ( distance % ( 1000 * 60 ) ) / 1000 );

   var element = document.querySelector( selector );
   if ( element ) {
    var hoursEl = element.querySelector( '.hours' );
    var minutesEl = element.querySelector( '.minutes' );
    var secondsEl = element.querySelector( '.seconds' );

    if ( hoursEl ) hoursEl.innerHTML = hours;
    if ( minutesEl ) minutesEl.innerHTML = minutes;
    if ( secondsEl ) secondsEl.innerHTML = seconds;
   }

   if ( distance < 0 ) {
    clearInterval( x );
    if ( element ) {
     element.innerHTML = "EXPIRED";
    }
   }
  }, 1000 );
 } catch ( error ) {
  console.error( 'Timer initialization error:', error );
 }
};

// Wishlist toggle
window.toggleWishlist = function ( element ) {
 try {
  if ( element ) {
   element.classList.toggle( 'active' );
  }
 } catch ( error ) {
  console.error( 'Wishlist toggle error:', error );
 }
};