/** @type {import('tailwindcss').Config} */
export default {
	content: ["./index.html", "./src/**/*.{vue,js,ts,jsx,tsx}"],
	theme: {
		colors: {
			primary: "#BEEBE5",
			"primary-100": "#00ffd1",
			"primary-700": "#005845",
			secondary: "#ec6608",
			"secondary-800": "#ff0000",
			white: "#fff",
			light: "#e8f1ee",
			"light-100": "#f4f8f7",
			"light-300": "#d7e3e0",
			"light-500": "#afc7c0",
			"light-700": "#d8d8d8",
			"light-800": "#DFE2E2",
			gray: "#8c8c8c",
			"gray-200": "#E0E0E0",
			"gray-300": "#EFEFEF",
			dark: "#616365",
			"dark-700": "#1F1E2E",
			black: "#000",
			"blue-100": "#8EE4FF",
			"pink-400": "#FF8989",
			danger: "#ff0000",
			success: "#008B7F",
			"danger-100": "#fff3f3",
			transparent: "transparent",
			"rose-500": "#f44336",
		},
		extend: {
			fontSize: {
				0: "0rem",
			},
			screens: {
				"3xl": "1700px",
			},
		},
	},
	plugins: [],
};
