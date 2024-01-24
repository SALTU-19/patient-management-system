import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [vue()],
  resolve: {
    alias: {
      "@": "/src", // This maps '@' to 'src' in your project
      find: "src",
    },
  },
  server: {
    port: 8080,
    host: true
  },
})
