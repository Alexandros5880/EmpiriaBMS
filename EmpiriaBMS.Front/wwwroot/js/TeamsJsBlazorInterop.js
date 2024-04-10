export function initializeAsync() {
  return microsoftTeams.app.initialize();
}

export function getContextAsync() {
  return microsoftTeams.app.getContext();
}

export function setCurrentFrame(contentUrl, websiteUrl) {
  microsoftTeams.pages.setCurrentFrame(contentUrl, websiteUrl);
}

export function registerFullScreenHandler() {
  return microsoftTeams.pages.registerFullScreenHandler();
}

export function registerChangeConfigHandler() {
  microsoftTeams.pages.config.registerChangeConfigHandler();
}

export function getTabInstances(tabInstanceParameters) {
  return microsoftTeams.pages.tabs.getTabInstances(tabInstanceParameters);
}

export function getMruTabInstances(tabInstanceParameters) {
  return microsoftTeams.pages.tabs.getMruTabInstances(tabInstanceParameters);
}

export function shareDeepLink(deepLinkParameters) {
  microsoftTeams.pages.shareDeepLink(deepLinkParameters);
}

export function openLink(deepLink) {
  return microsoftTeams.app.openLink(deepLink);
}

export function navigateToTab(tabInstance) {
  return microsoftTeams.pages.tabs.navigateToTab(tabInstance);
}

// Settings module
export function registerOnSaveHandler(settings) {
  microsoftTeams.pages.config.registerOnSaveHandler((saveEvent) => {
    microsoftTeams.pages.config.setConfig(settings);
    saveEvent.notifySuccess();
  });

  microsoftTeams.pages.config.setValidityState(true);
}

// Come from here: https://github.com/wictorwilen/msteams-react-base-component/blob/master/src/useTeams.ts
export function inTeams() {
  if (
    (window.parent === window.self && window.nativeInterface) ||
    window.navigator.userAgent.includes("Teams/") ||
    window.name === "embedded-page-container" ||
    window.name === "extension-tab-frame"
  ) {
    return true;
  }
  return false;
}

export function getScreenSize() {
    return {
        width: window.innerWidth,
        height: window.innerHeight
    };
};

export function navigateToAdmin(url, objectId) {
    fetch(url, {
        method: 'GET',
        headers: {
            'ObjectId': objectId
        }
    }).then(response => {
        if (response.ok) {
            window.location.href = response.url; // Redirect to the returned URL
        } else {
            console.error('Failed to navigate:', response.status);
        }
    }).catch(error => {
        console.error('Error navigating:', error);
    });
}


// Cookies
export function setCookie(key, value) {
    localStorage.setItem(key, value);
}

export function getCookie(key) {
    return localStorage.getItem(key);
}
// Cookies


// Canvas
export function initializeCanvas(canvas) {
    // Touch
    const contextTouche = canvas.getContext('2d');
    const ongoingTouches = [];
    var offsetX;
    var offsetY;

    // Touch events
    canvas.addEventListener('touchstart', handleTouchStart);
    canvas.addEventListener('touchmove', handleTouchMove);
    canvas.addEventListener('touchend', handleTouchEnd);
    canvas.addEventListener('touchcancel', handleTouchCancel);

    function handleTouchStart(evt) {
        evt.preventDefault();
        const touches = evt.changedTouches;
        offsetX = canvas.getBoundingClientRect().left;
        offsetY = canvas.getBoundingClientRect().top;
        console.log(offsetX, offsetY)
        for (let i = 0; i < touches.length; i++) {
            ongoingTouches.push(copyTouch(touches[i]));
        }
    }
    function handleTouchEnd(evt) {
        evt.preventDefault();
        const touches = evt.changedTouches;
        for (let i = 0; i < touches.length; i++) {
            const color = document.getElementById('selColor').value;
            let idx = ongoingTouchIndexById(touches[i].identifier);
            if (idx >= 0) {
                contextTouche.lineWidth = document.getElementById('selWidth').value;
                contextTouche.fillStyle = color;
                ongoingTouches.splice(idx, 1);  // remove it; we're done
            }
        }
    }
    function handleTouchCancel(evt) {
        evt.preventDefault();
        const touches = evt.changedTouches;
        for (let i = 0; i < touches.length; i++) {
            let idx = ongoingTouchIndexById(touches[i].identifier);
            ongoingTouches.splice(idx, 1);  // remove it; we're done
        }
    }
    function handleTouchMove(evt) {
        evt.preventDefault();
        const touches = evt.changedTouches;
        for (let i = 0; i < touches.length; i++) {
            const idx = ongoingTouchIndexById(touches[i].identifier);
            if (idx >= 0) {
                contextTouche.beginPath();
                contextTouche.moveTo(ongoingTouches[idx].clientX - offsetX, ongoingTouches[idx].clientY - offsetY);
                contextTouche.lineTo(touches[i].clientX - offsetX, touches[i].clientY - offsetY);
                contextTouche.lineWidth = 2;
                contextTouche.strokeStyle = '#000';
                contextTouche.lineJoin = "round";
                contextTouche.closePath();
                contextTouche.stroke();
                ongoingTouches.splice(idx, 1, copyTouch(touches[i]));  // swap in the new touch record
            }
        }
    }
    function copyTouch({ identifier, clientX, clientY }) {
        return { identifier, clientX, clientY };
    }
    function ongoingTouchIndexById(idToFind) {
        for (let i = 0; i < ongoingTouches.length; i++) {
            const id = ongoingTouches[i].identifier;
            if (id === idToFind) {
                return i;
            }
        }
        return -1;    // not found
    }

    // Mouse
    const contextMouse = canvas.getContext('2d');
    var pos = { x: 0, y: 0 };
    var isDrawing = false;

    // Mouse Events
    canvas.addEventListener('mousedown', onMouseDown);
    canvas.addEventListener('mousemove', onMouseMove);
    window.addEventListener('mouseup', onMouseUp);
    canvas.addEventListener('mouseenter', onMouseEnter);

    function onMouseDown(e) {
        isDrawing = true;
        onMouseEnter(e);
    }
    function onMouseMove(e) {
        if (isDrawing === true) {
            let { x, y } = { x: e.offsetX, y: e.offsetY };
            drawLine(pos.x, pos.y, x, y);
            onMouseEnter(e);
        }
    }
    function onMouseUp() {
        isDrawing = false;
    }
    function onMouseEnter(e) {
        var rect = canvas.getBoundingClientRect();
        pos.x = e.clientX - rect.left;
        pos.y = e.clientY - rect.top;
    }
    function drawLine(x1, y1, x2, y2) {
        contextMouse.beginPath();
        contextMouse.strokeStyle = '#000';
        contextMouse.lineWidth = 2;
        contextMouse.moveTo(x1, y1);
        contextMouse.lineTo(x2, y2);
        contextMouse.stroke();
        contextMouse.closePath();
    }
}

export function clearCanvas(canvas) {
    var context = canvas.getContext('2d');
    context.clearRect(0, 0, canvas.width, canvas.height);
}

export function getCanvasImageData(canvas) {
    var imgData = canvas.toDataURL(); // Get image data as base64 URL
    var base64 = imgData.replace(/^data:image\/(png|jpeg);base64,/, ""); // Remove header
    var byteCharacters = atob(base64); // Decode base64 to byte characters
    var byteNumbers = new Array(byteCharacters.length);

    // Convert byte characters to byte numbers
    for (var i = 0; i < byteCharacters.length; i++) {
        byteNumbers[i] = byteCharacters.charCodeAt(i);
    }

    // Create byte array
    var byteArray = new Uint8Array(byteNumbers);
    return byteArray;
}
// Canvas

// Google Maps Api
export function displayAddress(mapElementId, address) {
    var map = new google.maps.Map(document.getElementById(mapElementId), {
        center: { lat: -34.397, lng: 150.644 },
        zoom: 8
    });
    var geocoder = new google.maps.Geocoder();

    address.forEach(function (add) {
        geocoder.geocode({ 'address': add }, function (results, status) {
            if (status === 'OK') {
                map.setCenter(results[0].geometry.location);
                var marker = new google.maps.Marker({
                    map: map,
                    position: results[0].geometry.location
                });
            } else {
                console.log('Geocode was not successful for the following reason: ' + status);
            }
        });
    });
}

// Navigate
export function openDirectionsInNewWindow(directionsUrl) {
    window.open(directionsUrl, '_blank');
};

// Autocomplete
export function initializeAutocomplete(inputElementId) {
    const input = document.getElementById(inputElementId);
    const autocomplete = new google.maps.places.Autocomplete(input);
    autocomplete.addListener('place_changed', () => {
        const place = autocomplete.getPlace();
        if (!place.geometry) {
            // Place details not found for the input.
            return;
        }
        // Handle place details (if needed)
    });
};
// Google Maps Api