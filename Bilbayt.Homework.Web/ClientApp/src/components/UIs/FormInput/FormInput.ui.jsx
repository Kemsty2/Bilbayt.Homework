import { useState } from "react";
import PropTypes from "prop-types";
import Icon from "@iconify/react";
import eyeShowSolid from "@iconify/icons-fa-solid/eye";
import eyeHideSolid from "@iconify/icons-fa-solid/eye-slash";

import { Input } from "./FormInput.styles";

const FormInput = ({
  showable = false,
  label = "",
  type = "text",
  ...rest
}) => {
  const [show, setShow] = useState(false);

  const togglePassword = (e) => {
    e.preventDefault();

    setShow(!show);
  };

  return (
    <>
      {label ? <label className="form-input-label">{label}</label> : null}
      {type !== "password" ? (
        <Input type={type ? type : "text"} {...rest} />
      ) : showable ? (
        <>
          <Input type={show ? "text" : "password"} {...rest} />
          <Icon
            icon={!show ? eyeShowSolid : eyeHideSolid}
            onClick={togglePassword}
            style={{
              color: "#000",
              fontSize: "1.1em",
              bottom: "31px",
              left: "370px",
              position: "relative",
            }}
          />
        </>
      ) : (
        <Input type="password" {...rest} />
      )}
    </>
  );
};

export default FormInput;

FormInput.prototype = {
  showable: PropTypes.bool,
  label: PropTypes.string,
};
