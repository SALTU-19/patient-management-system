<script>
import IconCamera from "../icons/IconCamera.vue";
import IconTrash from "../icons/IconTrash.vue";

export default {
    name: "InputFile",
    props: {
        type: {
            type: String,
        },
        previewImage: {
            default: null,
            type: String,
        },
    },
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
        flushImage(e) {
            e.preventDefault();
            console.log("flush");
            this.newImage = null;
            this.$emit("new-image", this.newImage);
        },
    },
    data() {
        return {
            newImage: null,
            maxWidth: 150,
            maxHeight: 150,
        };
    },
    emits: ["new-image"],
    components: { IconCamera, IconTrash },
    mounted() {
        this.newImage = this.previewImage;
    },
};
</script>

<template>
    <div class="file">
        <label>
            <template v-if="type == 'image' && !newImage">
                <input type="file" accept="image/jpeg, .png" @change="handleFileChange" />
                <span class="file-image">
                    <IconCamera />
                </span>
            </template>
            <template v-else>
                <input type="file" accept="image/jpeg, .png" @change="handleFileChange" />
                <button class="flex justify-center items-center ml-28 w-3 h-3" @click="flushImage" type="button">
                    <IconTrash />
                </button>
                <div class="profile-image">
                    <img :src="newImage" alt="preview" />
                </div>
            </template>
        </label>
    </div>
</template>

<style lang="scss" scoped>
.file {
    input {
        @apply hidden;
    }

    &-image {
        @apply flex justify-center items-center w-32 h-32 text-white rounded-full bg-light-700 overflow-hidden cursor-pointer;
    }
}

.profile {
    @apply flex flex-col justify-center items-center gap-3;

    &-image {
        @apply border-light rounded-full bg-light -rotate-45 overflow-hidden cursor-pointer;
        width: 130px;
        height: 130px;
        border-width: 8px;

        img {
            @apply w-full h-full object-cover rotate-45;
        }
    }
}
</style>