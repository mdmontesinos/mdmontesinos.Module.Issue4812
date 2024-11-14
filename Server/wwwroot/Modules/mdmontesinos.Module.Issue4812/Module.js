export async function onUpdate() {
    setTimeout(() => initializeMasonry(), 500);
}

function initializeMasonry() {
    let msnry = new Masonry('.masonry-grid', {
        percentPosition: true
    });

    let imgLoad = imagesLoaded('.masonry-grid');

    imgLoad.on('progress', function (instance, image) {
        console.log("Image loaded: ", image.img.src);
        msnry.layout();
    });
}