<template>
    <div>
        <input type="file" @change="handleFileChange" accept="image/*" />
    </div>
</template>
  
<script>
export default {
    name: "ImageFile",
    props: {},
    methods: {
        handleFileChange(e) {
            const file = e.target.files[0];
            const reader = new FileReader();
            reader.readAsDataURL(file);
            reader.onload = () => {
                // console.log(reader.result);
                this.resizeImage(reader.result);
            };
        },
        resizeImage(dataUrl) {
            const img = new Image();
            img.src = dataUrl;
            img.onload = () => {
                const aspectRatio = img.width / img.height;

                let newWidth = img.width;
                let newHeight = img.height;

                if (newWidth > this.maxWidth) {
                    newWidth = this.maxWidth;
                    newHeight = newWidth / aspectRatio;
                }

                if (newHeight > this.maxHeight) {
                    newHeight = this.maxHeight;
                    newWidth = newHeight * aspectRatio;
                }

                const canvas = document.createElement("canvas");
                const ctx = canvas.getContext("2d");
                canvas.width = newWidth;
                canvas.height = newHeight;

                ctx.drawImage(img, 0, 0, newWidth, newHeight);

                this.newImage = canvas.toDataURL("image/jpeg"); // Adjust the format as needed
                this.$emit("new-image", this.newImage);
            };
        },
    },
    emits: ["new-image"],
    mounted() { },
};
</script>
  
<style lang="scss" scoped></style>
  