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


// Register MNouse Weel Event
export function registerGlobalMouseWheelEvent(objRef, id) {
    $('[data-id="' + id + '"]').on('wheel', function (e) {
        var deltaY = e.originalEvent.deltaY;
        var focusedElement = $(':focus');
        if (focusedElement.is('[data-id="' + id + '"]')) {
            var inputType = focusedElement.data("input-type");
            var inputId = focusedElement.data("id");

            //var currentValue = parseInt(focusedElement.val());
            //var max = parseInt(focusedElement.attr("max"));
            //var min = parseInt(focusedElement.attr("min"));

            //console.log("currentValue: ", currentValue);
            //console.log("max: ", max);
            //console.log("min: ", min);
            //if (currentValue > max) {
            //    focusedElement.val(max);
            //    console.log("currentValue > max");
            //}
            //else if (currentValue < min) {
            //    focusedElement.val(min);
            //    console.log("currentValue < min");
            //}

            if (id == inputId) {
                if (inputType === "hours") {
                    objRef.invokeMethodAsync('OnMouseWheel', deltaY, "hours");
                    //DotNet.invokeMethodAsync('EmpiriaBMS.Front', 'OnMouseWheel', deltaY, "hours");
                } else if (inputType === "minutes") {
                    objRef.invokeMethodAsync('OnMouseWheel', deltaY, "minutes");
                    //DotNet.invokeMethodAsync('EmpiriaBMS.Front', 'OnMouseWheel', deltaY, "minutes");
                }
            }
        }
    });
}
// Register MNouse Weel Event


// Cookies
export function setCookie(key, value) {
    localStorage.setItem(key, value);
}

export function getCookie(key) {
    return localStorage.getItem(key);
}
// Cookies


// Canvas
var signaturePad;

export function initializeCanvas(canvas) {
    fitToContainer(canvas);
    signaturePad = new SignaturePad(canvas);
}

function fitToContainer(canvas) {
    // Make it visually fill the positioned parent
    canvas.style.width = '100%';
    canvas.style.height = '100%';
    // ...then set the internal size to match
    canvas.width = canvas.offsetWidth;
    canvas.height = canvas.offsetHeight;
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
        zoom: 12
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
                console.log('Geocode was successful location: ' + results[0].geometry.location);
            } else {
                console.log('Geocode was not successful for the following reason: ' + status);
            }
        }, error => console.log('Geocode error: ' + error));
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



// Download Document
export function downloadFile(fileName, contentType, base64Content) {
    const byteArray = Uint8Array.from(atob(base64Content), c => c.charCodeAt(0));
    const blob = new Blob([byteArray], { type: contentType });
    const url = URL.createObjectURL(blob);

    const a = document.createElement('a');
    a.href = url;
    a.download = fileName;
    document.body.appendChild(a);
    a.click();

    document.body.removeChild(a);
    URL.revokeObjectURL(url);
};
// Download Document


// Pick Folder Path
async function pickFolder() {
    try {
        // Create an empty CSV Blob
        const emptyCsvBlob = new Blob([""], { type: 'text/csv' });

        // Create an input element
        const input = document.createElement('input');
        input.type = 'file';
        input.accept = '.csv';

        // Preselect the empty CSV file
        const dataTransfer = new DataTransfer();
        dataTransfer.items.add(new File([emptyCsvBlob], "output.csv", { type: 'text/csv' }));
        input.files = dataTransfer.files;

        return new Promise((resolve, reject) => {
            input.onchange = (event) => {
                const file = event.target.files[0];
                if (file) {
                    resolve(file.name); // Resolve with the file name
                } else {
                    reject(new Error('No file selected'));
                }
            };

            // Simulate a click to open the file picker dialog
            input.click();
        });
    } catch (err) {
        console.error(err);
        return null;
    }
}

export async function pickFolderPath() {
    return await pickFolder();
}
// - Pick Folder Path

// Download CSV
export function downloadCsvFile(filename, content) {
    var blob = new Blob([content], { type: 'text/csv;charset=utf-8;' });
    var link = document.createElement("a");
    if (link.download !== undefined) {
        var url = URL.createObjectURL(blob);
        link.setAttribute("href", url);
        link.setAttribute("download", filename);
        link.style.visibility = 'hidden';
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);
    }
}
// - Download CSV


// Element Click
export function triggerFileInputClick(element) {
    element.click();
};
// - Element Click