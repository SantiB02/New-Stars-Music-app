import { ErrorMessage, useFormik } from "formik";
import React from "react";
import { yup, object, string, number, date, InferType } from "yup";

const Login = () => {
  const loginHandler = ({ email, password }) => {
    if (!email || !password) {
      return;
    }
  };

  const loginValidationScheme = yup.object().shape({
    email: yup
      .string()
      .required("Este campo es obligatorio")
      .email("Enter a valid email")
      .max(20, "Your email can't have more than 20 characters")
      .min(5, "Your email can't have less than 5 characters"),
    password: yup
      .string()
      .required("This field is mandatory")
      .min(5, "Your password can't have less than 5 characters"),
  });

  const initialState = {
    email: "",
    password: "",
  };
  const formik = useFormik({
    initialValue: initialState,
    validateSchema: loginValidationScheme,
    validateOnBlur: true,
    validateOnChange: false,
    onSubmit() {
      loginHandler(formik.values.email, formik.values.password);
    },
  });

  return (
    <div>
      <form>
        <label htmlFor="email">Email:</label>
        <input
          type="email"
          id="email"
          value={formik.values.email}
          onChange={formik.handleChange}
          onBlur={formik.handleBlur}
        />
        {formik.errors.email && formik.touched.email ? (
          <label>{errors.email}</label>
        ) : null}
              <ErrorMessage name="email" />
              <label htmlFor="password">Password:</label>
              <input type="password" />
      </form>
    </div>
  );
};

export default Login;
