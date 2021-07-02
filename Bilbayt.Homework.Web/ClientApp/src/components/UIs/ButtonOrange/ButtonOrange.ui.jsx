import React from "react";
import { Icon } from "@iconify/react";
import classNames from "classnames";

import {
  Button,
  LinkButton,
  ClassicLinkButton,
  ClassicLink,
  Span,
} from "./ButtonOrange.styles";

const ButtonOrange = ({
  children,
  typebutton = "button",
  classbutton = "primary",
  icon = null,
  isLoading = false,
  ...props
}) => {
  return typebutton === "button" || typebutton === "submit" ? (
    <Button
      icon={icon}
      classbutton={classbutton}
      {...props}
      className={classNames(
        "ld-ext-right ",
        {
          running: isLoading,
        },
        props.className
      )}
      disabled={isLoading}
    >
      <div className="ld ld-ring ld-spin"></div>
      {children}
      {icon && (
        <Span>
          <Icon icon={icon} color="#F16E00" style={{ fontSize: "24px" }} />
        </Span>
      )}
    </Button>
  ) : typebutton === "link" ? (
    <LinkButton icon={icon} classbutton={classbutton} {...props}>
      {children}
      {icon && (
        <Span>
          <Icon icon={icon} color="#F16E00" style={{ fontSize: "24px" }} />
        </Span>
      )}
    </LinkButton>
  ) : typebutton === "classic-link" ? (
    <ClassicLinkButton icon={icon} classbutton={classbutton} {...props}>
      {children}
      {icon && (
        <Span>
          <Icon icon={icon} color="#F16E00" style={{ fontSize: "24px" }} />
        </Span>
      )}
    </ClassicLinkButton>
  ) : (
    <ClassicLink {...props}>{children}</ClassicLink>
  );
};

export default ButtonOrange;
