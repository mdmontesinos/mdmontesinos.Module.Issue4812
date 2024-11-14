window.mdmontesinos = window.mdmontesinos || {};

window.mdmontesinos.Issue4812 = {
    initializeMasonry: function () {
        let msnry = new Masonry('.masonry-grid', {
            percentPosition: true
        });

        let imgLoad = imagesLoaded('.masonry-grid');

        imgLoad.on('progress', function (instance, image) {
            console.log("Image loaded: ", image.img.src);
            msnry.layout();
        });
    }
}

export async function onUpdate() {
    setTimeout(() => initializeMasonry(), 500);
    /*executeAndRetryFunction('mdmontesinos.Issue4812.initializeMasonry()')*/
}

//async function executeAndRetryFunction(fnStr, retries = 3, delay = 50) {
//    try {
//        var fn = new Function(fnStr);

//        if (fn) {
//            fn();
//            return true;
//        }
//    } catch (error) {
//        if (retries > 0) {
//            await new Promise(resolve => setTimeout(resolve, 1000));
//            return executeAndRetryFunction(fnStr, retries - 1, delay * 2);
//        }
//        else {
//            console.log(`Failed executing function ${fnStr}: ${error.message}`);
//            return false;
//        }
//    }

//    return false;
//}