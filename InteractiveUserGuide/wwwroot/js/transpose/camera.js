var InteractiveUserGuide = InteractiveUserGuide || {};
InteractiveUserGuide.Camera = InteractiveUserGuide.Camera || {};

$(function (ns) {

    var camera;
    var scene;
    var canvas;

    var cameraOriginalPosition;
    var cameraOriginalTarget;
    var cameraOriginalAlpha;
    var cameraOriginalBeta;

    var cameraPositionAnimFinished = false;
    var cameraTargetAnimFinished = false;
    var isElementCloseViewMode = false;

    $(function () {

    });

    InteractiveUserGuide.Camera.Setup = function (scene, canvas) {
        this.scene = scene;
        this.canvas = canvas;

        this.camera = new BABYLON.ArcRotateCamera("Camera", Math.PI / 2, Math.PI / 2, 2, new BABYLON.Vector3(0, 1, 0), scene);
        InteractiveUserGuide.Camera.EnableInput(true);
        this.camera.checkCollisions = true;

        this.camera.setPosition(new BABYLON.Vector3(0, 0, -50));

        this.camera.lowerRadiusLimit = 2;
        this.camera.upperRadiusLimit = 4;
        this.camera.upperBetaLimit = 1.75;
        this.camera.wheelDeltaPercentage = 0.01;
        this.camera.pinchPrecision = 20;                 // Make zoom slower on mobile devices, default value is 2

        // Set camera clipping
        this.camera.maxZ = 500;
        this.camera.minZ = 0;

        this.cameraOriginalPosition = this.camera.position;
        this.cameraOriginalTarget = this.camera.target;

        this.camera.onViewMatrixChangedObservable.add(function () {

            if (InteractiveUserGuide.Camera.isElementCloseViewMode) {


                var camera = InteractiveUserGuide.Camera.camera;

                // Checks if user is no longer interested in this element by ...
                if (camera.radius > 1.5                                                                 // Zooming out too far 
                    || camera.alpha > InteractiveUserGuide.Camera.cameraOriginalAlpha + 1               // Moving too far to the right
                    || camera.alpha < InteractiveUserGuide.Camera.cameraOriginalAlpha - 1               // Moving too far to the left
                    || camera.beta > InteractiveUserGuide.Camera.cameraOriginalBeta + 1                 // Moving too far up
                    || camera.beta < InteractiveUserGuide.Camera.cameraOriginalBeta - 1)                // Moving too far down
                {
                    InteractiveUserGuide.Camera.isElementCloseViewMode = false;
                    InteractiveUserGuide.Camera.EnableInput(false);
                    InteractiveUserGuide.Site.RemovePartInformation();

                    InteractiveUserGuide.Camera.AnimateCameraTo(InteractiveUserGuide.Camera.cameraOriginalTarget, InteractiveUserGuide.Camera.cameraOriginalPosition, 1, 3, function () {
                        //onFinished Animation
                        InteractiveUserGuide.Camera.ResetCamera();
                        InteractiveUserGuide.Camera.EnableInput(true);
                    });
                }
            }
        });
    }

    InteractiveUserGuide.Camera.ResetCamera = function () {
        this.camera.lowerRadiusLimit = 2;
        this.camera.upperRadiusLimit = 4;
        this.camera.upperBetaLimit = 1.75;
        this.camera.wheelDeltaPercentage = 0.01;
    }

    InteractiveUserGuide.Camera.FocusAt = function(mesh) {

        var newTarget = mesh.position;

        var newPosition = new BABYLON.Vector3;
        newPosition.x = mesh.position.x;
        newPosition.y = mesh.position.y;
        newPosition.z = -0.6 * mesh.forward.z;

        InteractiveUserGuide.Camera.EnableInput(false);

        // Allow bigger zoom
        this.camera.lowerRadiusLimit = 1;

        this.cameraOriginalPosition = this.camera.position;

        InteractiveUserGuide.Camera.AnimateCameraTo(newTarget, newPosition, 3, 1, function () {

            InteractiveUserGuide.Camera.cameraOriginalAlpha = InteractiveUserGuide.Camera.camera.alpha;
            InteractiveUserGuide.Camera.cameraOriginalBeta = InteractiveUserGuide.Camera.camera.beta;
            InteractiveUserGuide.Camera.isElementCloseViewMode = true;

            InteractiveUserGuide.Camera.EnableInput(true);
        });
    }

    InteractiveUserGuide.Camera.AnimateCameraTo = function (newTarget, newPosition, speed, duration, onFinished) {

        var ease = new BABYLON.CubicEase();
        ease.setEasingMode(BABYLON.EasingFunction.EASINGMODE_EASEINOUT);

        BABYLON.Animation.CreateAndStartAnimation('cameraAnimation1', this.camera, 'position', speed, duration, this.camera.position, newPosition, 0, ease, function () {

            cameraPositionAnimFinished = true;

            if (cameraTargetAnimFinished) {

                if (onFinished != null) {
                    onFinished();
                }
            }
        });

        BABYLON.Animation.CreateAndStartAnimation('cameraAnimation2', this.camera, 'target', speed, duration, this.camera.target, newTarget, 0, ease, function () {

            cameraTargetAnimFinished = true;

            if (cameraPositionAnimFinished) {

                if (onFinished != null) {
                    onFinished();
                }
            }
        });
    }

    InteractiveUserGuide.Camera.EnableInput = function (enable) {

        if (enable) {
            this.camera.attachControl(this.canvas, false);
        }
        else {
            this.camera.detachControl(this.canvas);
        }
    }

    InteractiveUserGuide.Camera.GetCamera = function () {
        return this.camera;
    }

}(window.InteractiveUserGuide = window.InteractiveUserGuide || {}));