export const HomeMainBanner = () => {
  return (
    <section
      className="relative bg-cover bg-center h-[70vh] md:h-screen flex items-center justify-center"
      style={{ backgroundImage: "url('./luegolapongo')" }} // Ni idea de si agregarle
    >
      <div className="absolute inset-0 bg-black opacity-60"></div>
      <div className="relative z-10 text-center max-w-xl md:max-w-3xl px-4">
        <h2 className="text-4xl md:text-6xl font-extrabold text-white">
          Aventuras Inolvidables Te Esperan
        </h2>
        <p className="text-lg md:text-2xl mt-4 md:mt-6 text-gray-300">
          Explora destinos únicos y vive experiencias que jamás olvidarás.
        </p>
        <div className="mt-6 md:mt-8">
          <a
            href="#"
            className="inline-block bg-yellow-500 text-gray-900 font-bold py-3 px-6 md:py-4 md:px-8 rounded-full shadow-lg hover:bg-yellow-400 transition"
          >
            Descubre Más
          </a>
          <a
            href="#"
            className="ml-2 md:ml-4 inline-block text-white font-bold py-3 px-6 md:py-4 md:px-8 rounded-full border border-yellow-500 hover:bg-yellow-500 hover:text-gray-900 transition"
          >
            Contáctanos
          </a>
        </div>
      </div>
    </section>
  );
};
