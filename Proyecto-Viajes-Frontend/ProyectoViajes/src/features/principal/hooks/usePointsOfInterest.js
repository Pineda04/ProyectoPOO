import { useEffect, useState } from 'react';
import axios from 'axios';

const usePointsOfInterest = (destinationId = null) => {
  const [data, setData] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchPointsOfInterest = async () => {
      let allPoints = [];
      let page = 1;
      let hasMorePages = true;

      while (hasMorePages) {
        try {
          const response = await axios.get('https://localhost:7234/api/points_interest', {
            params: { page }
          });

          const points = response.data.data.items;

          if (destinationId) {
            // Filtrar puntos de interés por el destinationId
            const filteredPoints = points.filter(point => point.destinationId === destinationId);
            allPoints = [...allPoints, ...filteredPoints];
          } else {
            allPoints = [...allPoints, ...points];
          }

          if (response.data.data.items.length === 0) {
            hasMorePages = false;
          } else {
            page += 1;
          }
        } catch (err) {
          setError(err.message);
          hasMorePages = false;
        }
      }

      setData(allPoints);
      setLoading(false);
    };

    fetchPointsOfInterest();
  }, [destinationId]);

  return { data, loading, error };
};

export default usePointsOfInterest;
