import { useState } from 'react';
import { HiMenuAlt3, HiX } from 'react-icons/hi';
import { FaHome, FaMapMarkerAlt, FaBox, FaCalendarCheck, FaPhone } from 'react-icons/fa';
import { Link } from 'react-router-dom';

export const Header = () => {
  const [isMenuOpen, setIsMenuOpen] = useState(false);

  const toggleMenu = () => {
    setIsMenuOpen(!isMenuOpen);
  };

  return (
    <header className="bg-gradient-to-r from-gray-800 to-gray-900 py-6 shadow-lg">
      <div className="container mx-auto flex flex-wrap items-center px-6">
        <h1 className="text-4xl font-extrabold text-yellow-500 flex-grow">
          TravelExperience
        </h1>
        {/* Inicia botón del menu de hamburguesa para pantallas medianas y pequeñas */}
        <div className="md:hidden flex-shrink-0">
          <button
            className="text-yellow-500 focus:outline-none"
            onClick={toggleMenu}
          >
            {isMenuOpen ? <HiX size={24} /> : <HiMenuAlt3 size={24} />}
          </button>
        </div>
        {/* Navegación y botones para pantallas grandes */}
        <nav className={`hidden md:flex md:space-x-6 text-lg flex-grow`}>
          <Link to="/home" className="hover:text-yellow-400 transition">
            Inicio
          </Link>
          <Link to="/destinations" className="hover:text-yellow-400 transition">
            Destinos
          </Link>
          <a href="#" className="hover:text-yellow-400 transition">
            Paquetes
          </a>
          <a href="#" className="hover:text-yellow-400 transition">
            Reservas
          </a>
          <a href="#" className="hover:text-yellow-400 transition">
            Contacto
          </a>
        </nav>
        {/* Botones de acción para pantallas grandes */}
        <div className="hidden md:flex space-x-4 flex-shrink-0">
          <button className="bg-yellow-500 text-gray-900 font-semibold py-2 px-4 rounded-lg shadow hover:bg-yellow-400 transition">
            Reserva Ahora
          </button>
          <a href="#" className="bg-gray-800 text-yellow-500 font-semibold py-2 px-4 rounded-lg border border-yellow-500 hover:bg-gray-700 transition">
            Iniciar Sesión
          </a>
        </div>
      </div>
      {/* Menu de navegación para pantallas medianas y pequeñas */}
      {isMenuOpen && (
        <div className="md:hidden bg-gray-800 text-yellow-500 p-4 space-y-4 mt-4 mb-0">
          <nav className="space-y-4">
            <Link to="/home" className="flex items-center space-x-3 hover:text-yellow-400 transition">
              <FaHome size={20} className="flex-shrink-0" />
              <span className="text-lg">Inicio</span>
            </Link>
            <Link to="/destinations" className="flex items-center space-x-3 hover:text-yellow-400 transition">
              <FaMapMarkerAlt size={20} className="flex-shrink-0" />
              <span className="text-lg">Destinos</span>
            </Link>
            <a href="#" className="flex items-center space-x-3 hover:text-yellow-400 transition">
              <FaBox size={20} className="flex-shrink-0" />
              <span className="text-lg">Paquetes</span>
            </a>
            <a href="#" className="flex items-center space-x-3 hover:text-yellow-400 transition">
              <FaCalendarCheck size={20} className="flex-shrink-0" />
              <span className="text-lg">Reservas</span>
            </a>
            <a href="#" className="flex items-center space-x-3 hover:text-yellow-400 transition">
              <FaPhone size={20} className="flex-shrink-0" />
              <span className="text-lg">Contacto</span>
            </a>
          </nav>
          {/* Botones de acción para pantallas pequeñas */}
          <div className="flex space-x-4 mt-4">
            <button className="bg-yellow-500 text-gray-900 font-semibold py-2 px-4 rounded-lg shadow hover:bg-yellow-400 transition">
              Reserva Ahora
            </button>
            <a href="#" className="bg-gray-800 text-yellow-500 font-semibold py-2 px-4 rounded-lg border border-yellow-500 hover:bg-gray-700 transition">
              Iniciar Sesión
            </a>
          </div>
        </div>
      )}
    </header>
  );
};
