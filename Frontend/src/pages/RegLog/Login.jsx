import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { useAuth } from '../../AuthContext'; // Provjerite je li putanja točna
import './Login.css';
import { RoutesNames } from '../../constants';
import { login as loginService, register } from '../../services/RegLogService'; // Preimenovano da izbjegne konfuziju

const AuthForm = () => {
  const [isLogin, setIsLogin] = useState(true);
  const [formData, setFormData] = useState({
    name: '',
    surname: '',
    email: '',
    password: '',
    confirmPassword: ''
  });

  const { login } = useAuth(); // Dohvaćanje funkcije login iz konteksta
  const navigate = useNavigate();

  const toggleForm = () => {
    setIsLogin(!isLogin);
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData(prevState => ({
      ...prevState,
      [name]: value
    }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    if (isLogin) {
      try {
        const { email, password } = formData;
        const data = await loginService(email, password);
        if (data && data.user) {
          login(data.user); // Ovdje se poziva login iz AuthContext s korisničkim podacima
          navigate(RoutesNames.HOME);
          alert("Prijava uspješna");
        } else {
          alert("Prijava neuspješna. Pokušajte ponovo.");
        }
      } catch (error) {
        console.error('Login error:', error);
        alert("Netočni email ili lozinka");
      }
    } else {
      try {
        const { name, surname, email, password, confirmPassword } = formData;
        if (password !== confirmPassword) {
          alert("Lozinke se ne podudaraju");
          return;
        }
        const data = await register(name, surname, email, password);
        console.log('Registration successful:', data);
        alert("Registracija uspješna");
        navigate(RoutesNames.HOME);
      } catch (error) {
        console.error('Registration error:', error);
        alert(error.message);
      }
    }
  };

  return (
    <div className="auth-form__container">
      <div className="auth-form__button-container">
        <button onClick={toggleForm} className={`auth-form__button ${isLogin ? 'auth-form__button--active' : ''}`}>
          LOGIN
        </button>
        <button onClick={toggleForm} className={`auth-form__button ${!isLogin ? 'auth-form__button--active' : ''}`}>
          REGISTER
        </button>
      </div>
      <form onSubmit={handleSubmit} className="auth-form">
        {isLogin ? (
          <div className="login-form">
            <input
              type="text"
              name="email"
              placeholder="Email ili korisničko ime"
              onChange={handleChange}
              value={formData.email}
            />
            <input
              type="password"
              name="password"
              placeholder="Lozinka"
              onChange={handleChange}
              value={formData.password}
            />
            <button type="submit" className="auth-form__submit-btn">PRIJAVI SE</button>
          </div>
        ) : (
          <div className="register-form">
            <input
              type="text"
              name="name"
              placeholder="Ime"
              onChange={handleChange}
              value={formData.name}
            />
            <input
              type="text"
              name="surname"
              placeholder="Prezime"
              onChange={handleChange}
              value={formData.surname}
            />
            <input
              type="email"
              name="email"
              placeholder="Email"
              onChange={handleChange}
              value={formData.email}
            />
            <input
              type="password"
              name="password"
              placeholder="Lozinka"
              onChange={handleChange}
              value={formData.password}
            />
            <input
              type="password"
              name="confirmPassword"
              placeholder="Ponovite lozinku"
              onChange={handleChange}
              value={formData.confirmPassword}
            />
            <button type="submit" className="auth-form__submit-btn">REGISTRIRAJ SE</button>
          </div>
        )}
      </form>
    </div>
  );
};

export default AuthForm;
