import styled, { css } from "styled-components";

const TitleCss = css`
  font-weight: bold;
  font-size: 26px;
  color: #000000;
  margin-bottom: 25px;
`;

export const AuthTitle = styled.h1`
  ${TitleCss}
`;

export const AuthSubTitle = styled.h2`
  font-size: 18px;
  margin-bottom: 15px;
`;

export const AuthText = styled.p`
  font-weight: normal;
  font-size: 16px;
  line-height: 33px;
  color: #000000;
  margin-bottom: 25px;
`;
