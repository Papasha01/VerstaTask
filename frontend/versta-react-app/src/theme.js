import { extendTheme } from '@chakra-ui/react';

const theme = extendTheme({
  semanticTokens: {
    colors: {
      // Устанавливаем белый фон по умолчанию
      'chakra-body-bg': { _light: '#ffffff', _dark: '#ffffff' }, // Фон для светлого и темного режимов
    },
  },
  styles: {
    global: {
      // Устанавливаем белый фон для body
      body: {
        bg: 'white', // или '#ffffff'
        color: 'gray.800', // Опционально: цвет текста для контраста
      },
    },
  },
});

export default theme;