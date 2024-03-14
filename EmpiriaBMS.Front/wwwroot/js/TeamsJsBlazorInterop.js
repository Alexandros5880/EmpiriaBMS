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

export function applyTimeMask(para) {
    var timeInput = document.getElementById(para.elementId);
    if (timeInput) {
        timeInput.addEventListener('input', function () {

            // Validate Mask
            var val = this.value;
            var lastLength;
            do {
                lastLength = val.length;
                val = replaceBadInputs(val);
            } while (val.length > 0 && lastLength !== val.length);
            this.value = val;

            // Validate Min Max Time
            validateMinMaxTime(this, val, para.minTime, para.maxTime);

        });

        function replaceBadInputs(val) {
            val = val.replace(/[^\dh:]/, "");
            val = val.replace(/^[^0-2]/, "");
            val = val.replace(/^([2-9])[4-9]/, "$1");
            val = val.replace(/^\d[:h]/, "");
            val = val.replace(/^([01][0-9])[^:h]/, "$1");
            val = val.replace(/^(2[0-3])[^:h]/, "$1");
            val = val.replace(/^(\d{2}[:h])[^0-5]/, "$1");
            val = val.replace(/^(\d{2}h)./, "$1");
            val = val.replace(/^(\d{2}:[0-5])[^0-9]/, "$1");
            val = val.replace(/^(\d{2}:\d[0-9])./, "$1");
            return val;
        }

        function validateMinMaxTime(self, val, min, max) {
            var inputTime = val;
            var minTime = min; // '08:00'
            var maxTime = max; // '18:00'

            if (inputTime < minTime || inputTime > maxTime) {
                $(self).addClass('invalid');
            } else {
                $(self).removeClass('invalid');
            }
        }
    }
};

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

export function setCookie(key, value) {
    localStorage.setItem(key, value);
}

export function getCookie(key) {
    return localStorage.getItem(key);
}

export function initializeCanvas(canvas) {
    canvas.addEventListener('mousemove', draw);
    canvas.addEventListener('mousedown', setPosition);
    canvas.addEventListener('mouseenter', setPosition);

    var context = canvas.getContext('2d');
    var pos = { x: 0, y: 0 };

    function setPosition(e) {
        var rect = canvas.getBoundingClientRect();
        pos.x = e.clientX - rect.left;
        pos.y = e.clientY - rect.top;
    }

    function draw(e) {
        if (e.buttons !== 1) return; // if mouse is not clicked, do not go further

        var color = "#000000"; // can be set to any color
        context.beginPath(); // begin the drawing path

        context.lineWidth = 2; // width of line
        context.lineCap = 'round'; // rounded end cap
        context.strokeStyle = color; // hex color of line

        context.moveTo(pos.x, pos.y); // from position
        setPosition(e);
        context.lineTo(pos.x, pos.y); // to position

        context.stroke(); // draw it!
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