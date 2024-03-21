const login = async (email, password) => {
    try {
      const response = await fetch('https://karlopet-001-site1.ktempurl.com/api/Account/login', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({ email, password })
      });
      const data = await response.json();
      if (response.ok) {
        return data;
      } else {
        throw new Error(data.message || 'Došlo je do pogreške prilikom prijave.');
      }
    } catch (error) {
      throw error;
    }
  };
  
  const register = async (firstName, lastName, email, password) => {
    try {
      const response = await fetch('https://karlopet-001-site1.ktempurl.com/api/Account/register', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({ firstName, lastName, email, password })
      });
      const data = await response.json();
      if (response.ok) {
        return data; // Ako je registracija uspješna, vrati podatke
      } else {
        throw new Error(data.message || 'Došlo je do pogreške prilikom registracije.');
      }
    } catch (error) {
      throw error; // Baca grešku dalje kako bi je mogli uhvatiti i obraditi u komponenti
    }
  };
  
  
  export { login, register };
  