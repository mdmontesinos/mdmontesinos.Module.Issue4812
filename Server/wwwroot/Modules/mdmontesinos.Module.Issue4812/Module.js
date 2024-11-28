export async function onUpdate() {
    await waitForMasonry();
    initializeMasonry();
}

function waitForMasonry() {
    return new Promise((resolve, reject) => {
        const checkInterval = 100; // Check every 100ms
        const timeout = 5000; // Timeout after 5 seconds

        let elapsedTime = 0;

        const interval = setInterval(() => {
            console.log("Checking for Masonry and imagesLoaded...");
            if (typeof Masonry !== 'undefined' && typeof imagesLoaded !== 'undefined') {
                clearInterval(interval);
                resolve();
            } else if (elapsedTime >= timeout) {
                clearInterval(interval);
                reject(new Error("Masonry or imagesLoaded script failed to load in time."));
            }
            elapsedTime += checkInterval;
        }, checkInterval);
    });
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

    let status = document.getElementById('status');
    status.innerHTML = 'Scripts loaded';
    status.className = 'text-success';
}
