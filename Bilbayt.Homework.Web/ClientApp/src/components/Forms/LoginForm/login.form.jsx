import { Link } from "react-router-dom";
import { useFormik } from "formik";
import * as Yup from "yup";

import { FormContainer } from "../../Container/AuthContainer.styles";
import FormInput from "../../UIs/FormInput/FormInput.ui";
import ButtonOrange from "../../UIs/ButtonOrange/ButtonOrange.ui";

import routes from "../../../configs/routes";

const LoginForm = ({ isLoading = false, onSubmit }) => {
  const validationSchema = Yup.object().shape({
    userName: Yup.string("Please enter a valid email")
      .required("UserName is required")
      .email("Please enter a valid email"),
    password: Yup.string()
      .required("Password is required")
      .matches(
        "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$",
        "Minimum eight characters, at least one uppercase letter, one lowercase letter and one number"
      ),
  });
  const formik = useFormik({
    initialValues: {
      userName: "",
      password: "",
    },
    validationSchema,
    onSubmit,
  });
  return (
    <FormContainer onSubmit={formik.handleSubmit}>
      <div className="form-group">
        <FormInput
          className="form-control"
          placeholder="UserName"
          onChange={formik.handleChange}
          name="userName"
          onBlur={formik.handleBlur}
          invalid={formik.touched.userName && formik.errors.userName}
        />
        {formik.touched.userName && formik.errors.userName && (
          <small className="form-text text-danger">
            {formik.errors.userName}
          </small>
        )}
      </div>
      <div className="form-group d-inline">
        <FormInput
          className="form-control d-inline"
          placeholder="Password"
          type="password"
          showable={true}
          onChange={formik.handleChange}
          onBlur={formik.handleBlur}
          name="password"
          invalid={formik.touched.password && formik.errors.password}
        />
        {formik.touched.password && formik.errors.password && (
          <small className="form-text text-danger mb-2 mt-1">
            {formik.errors.password}
          </small>
        )}
      </div>
      <div className="d-flex justify-content-between align-items-center">
        <ButtonOrange isLoading={isLoading} type="submit">
          Login
        </ButtonOrange>
        <span className="special-text">
          Don't have an account , Please{" "}
          <Link className="text-orange" to={routes.signup}>
            {" "}
            Sign Up
          </Link>
        </span>
      </div>
    </FormContainer>
  );
};

export default LoginForm;
