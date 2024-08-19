import { useState, useEffect } from 'react';
import axios from 'axios';

export const useAssessments = (packageId) => {
  const [data, setData] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const getAssessments = async () => {
      try {
        const response = await axios.get('https://localhost:7234/api/assessments');
        setData(response.data.data.items || []);
      } catch (err) {
        setError(err.message);
      } finally {
        setLoading(false);
      }
    };

    getAssessments();
  }, [packageId]);

  return { data, loading, error };
};