<template>
    <div>
        <input type="file" @change="handlePDFUpload" accept="application/pdf" />
        <button class="bg-primary text-black rounded-2xl px-4 py-2" @click="downloadPDF"
            :disabled="newPdf.base64 == ''">Download
            PDF</button>
    </div>
</template>
  
<script>


export default {
    name: "PdfFile",
    props: {
        // initialBase64: String, // New prop for initial base64 string from the parent default: "",

        initialBase64: {
            type: String,
            default: "",
        },
    },
    methods: {
        async handlePDFUpload(event) {
            const file = event.target.files[0];

            if (file) {
                // Convert the PDF file to a base64 string
                const base64String = await this.convertToBase64(file);

                this.newPdf = {
                    name: file.name,
                    base64: base64String,
                };

                this.$emit("new-pdf", this.newPdf);
                // Add more logic here to handle the file
            }
        },
        async convertToBase64(file) {
            return new Promise((resolve, reject) => {
                const reader = new FileReader();

                reader.onload = () => {
                    resolve(reader.result.split(",")[1]);
                };

                reader.onerror = (error) => {
                    reject(error);
                };

                reader.readAsDataURL(file);
            });
        },
        downloadPDF() {
            if (this.newPdf) {
                // Assuming 'download' attribute is supported
                const url = `data:application/pdf;base64,${this.newPdf.base64}`;
                const a = document.createElement("a");
                a.href = url;
                a.download = this.newPdf.name;
                document.body.appendChild(a);
                a.click();
                document.body.removeChild(a);
            }
        },
    },
    data() {
        return {
            newPdf: {
                name: "", // Initialize with an empty name
                base64: this.initialBase64 || "", // Use the provided initial base64 string or an empty string
            },
        };
    },
    emits: ["new-pdf"],
    mounted() { },
};
</script>
  
<style lang="scss" scoped></style>
  