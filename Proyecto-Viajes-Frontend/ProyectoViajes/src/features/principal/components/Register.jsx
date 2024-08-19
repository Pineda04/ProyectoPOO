import { useState } from "react";
import { Link } from "react-router-dom";
import { registerUser } from "../../../shared/actions/users/users";

export const Register = () => {
  const [formData, setFormData] = useState({
    name: "",
    email: "",
    password: "",
    confirmPassword: ""
  });
  const [error, setError] = useState(null);

  const handleChange = (event) => {
    const { name, value } = event.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleRegister = async (event) => {
    event.preventDefault();

    // Validar que las contraseñas coincidan
    if (formData.password !== formData.confirmPassword) {
      setError("Las contraseñas no coinciden");
      return;
    }

    // Limpiar errores previos
    setError(null);

    try {
      const currentDate = new Date().toISOString();

      // Enviar los datos 
      const response = await registerUser({
        name: formData.name,
        email: formData.email,
        password: formData.password,
        registrationDate: currentDate
      });

      if (response?.status === 200) {
        window.location.href = "/login";
      } else {
        window.location.href = "/login";
      }
    } catch (error) {
      window.location.href = "/login";
    }
  };

  return (
    <main className="flex-1 flex items-center justify-center bg-gray-800 py-12">
      <div className="container mx-auto px-4 max-w-sm sm:max-w-md lg:max-w-lg bg-gray-700 rounded-xl shadow-xl border border-gray-600">
        <h2 className="text-3xl font-bold text-yellow-500 text-center mb-6 mt-8">
          Regístrate
        </h2>
        <form className="space-y-6 p-8" onSubmit={handleRegister}>
          <div>
            <label
              htmlFor="name"
              className="block text-gray-300 text-sm font-semibold mb-2"
            >
              Nombre
            </label>
            <input
              type="text"
              id="name"
              name="name"
              value={formData.name}
              onChange={handleChange}
              className="w-full p-3 bg-gray-800 border border-gray-600 rounded-lg text-gray-100 placeholder-gray-500 focus:outline-none focus:ring-2 focus:ring-yellow-500"
              placeholder="Introduce tu nombre completo"
              required
            />
          </div>
          <div>
            <label
              htmlFor="email"
              className="block text-gray-300 text-sm font-semibold mb-2"
            >
              Correo Electrónico
            </label>
            <input
              type="email"
              id="email"
              name="email"
              value={formData.email}
              onChange={handleChange}
              className="w-full p-3 bg-gray-800 border border-gray-600 rounded-lg text-gray-100 placeholder-gray-500 focus:outline-none focus:ring-2 focus:ring-yellow-500"
              placeholder="Introduce tu correo electrónico"
              required
            />
          </div>
          <div>
            <label
              htmlFor="password"
              className="block text-gray-300 text-sm font-semibold mb-2"
            >
              Contraseña
            </label>
            <input
              type="password"
              id="password"
              name="password"
              value={formData.password}
              onChange={handleChange}
              className="w-full p-3 bg-gray-800 border border-gray-600 rounded-lg text-gray-100 placeholder-gray-500 focus:outline-none focus:ring-2 focus:ring-yellow-500"
              placeholder="Introduce tu contraseña"
              required
            />
          </div>
          <div>
            <label
              htmlFor="confirm-password"
              className="block text-gray-300 text-sm font-semibold mb-2"
            >
              Confirmar Contraseña
            </label>
            <input
              type="password"
              id="confirm-password"
              name="confirmPassword"
              value={formData.confirmPassword}
              onChange={handleChange}
              className="w-full p-3 bg-gray-800 border border-gray-600 rounded-lg text-gray-100 placeholder-gray-500 focus:outline-none focus:ring-2 focus:ring-yellow-500"
              placeholder="Confirma tu contraseña"
              required
            />
          </div>
          <button
            type="submit"
            className="w-full bg-yellow-500 text-gray-900 font-semibold py-2 px-4 rounded-lg shadow-lg hover:bg-yellow-400 transition"
          >
            Regístrate
          </button>
          <p className="text-gray-400 text-center mt-4">
            ¿Ya tienes una cuenta?{" "}
            <Link
              to="/login"
              className="text-yellow-400 hover:text-yellow-300 transition"
            >
              Inicia sesión aquí
            </Link>
          </p>
        </form>
      </div>
    </main>
  );
};
