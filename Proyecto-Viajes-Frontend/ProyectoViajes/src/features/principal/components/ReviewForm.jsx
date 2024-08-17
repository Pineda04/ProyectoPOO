import { useState } from "react";
import { FaStar } from "react-icons/fa";

export const ReviewForm = () => {
    const [newReview, setNewReview] = useState({ rating: 0, comment: '' });
    const [hoverRating, setHoverRating] = useState(undefined);
  
    const handleReviewChange = (e) => {
      setNewReview({ ...newReview, [e.target.name]: e.target.value });
    };
  
    const handleRatingChange = (rating) => {
      setNewReview({ ...newReview, rating });
    };
  
    const handleSubmitReview = (e) => {
      e.preventDefault();
      // aqui meto la logica despues
    };
  
    return (
      <section className="bg-gray-700 p-6 rounded-lg shadow-lg mb-12">
              <h3 className="text-2xl font-semibold text-yellow-500 mb-6">Añadir Valoración</h3>
              <form onSubmit={handleSubmitReview}>
                <div className="mb-4">
                  <label className="block text-gray-300 mb-2">Calificación</label>
                  <div className="flex space-x-1">
                    {[1, 2, 3, 4, 5].map((rating) => (
                      <FaStar
                        key={rating}
                        className={`cursor-pointer ${rating <= (hoverRating || newReview.rating) ? 'text-yellow-500' : 'text-gray-500'}`}
                        onClick={() => handleRatingChange(rating)}
                        onMouseEnter={() => setHoverRating(rating)}
                        onMouseLeave={() => setHoverRating(newReview.rating)}
                      />
                    ))}
                  </div>
                </div>
                <div className="mb-4">
                  <label className="block text-gray-300 mb-2" htmlFor="comment">
                    Comentario
                  </label>
                  <textarea
                    id="comment"
                    name="comment"
                    value={newReview.comment}
                    onChange={handleReviewChange}
                    rows="4"
                    className="w-full bg-gray-800 border border-gray-600 rounded-lg p-2 text-gray-200"
                    placeholder="Escribe tu comentario aquí..."
                  />
                </div>
                <button
                  type="submit"
                  className="bg-yellow-500 text-gray-900 font-semibold py-2 px-4 rounded-lg hover:bg-yellow-400 transition"
                >
                  Enviar Valoración
                </button>
              </form>
            </section>
    );
}