import * as React from "react";
import Avatar from "@mui/material/Avatar";
import Button from "@mui/material/Button";
import CssBaseline from "@mui/material/CssBaseline";
import TextField from "@mui/material/TextField";
import FormControlLabel from "@mui/material/FormControlLabel";
import Checkbox from "@mui/material/Checkbox";
import Link from "@mui/material/Link";
import Grid from "@mui/material/Grid";
import Box from "@mui/material/Box";
import LockOutlinedIcon from "@mui/icons-material/LockOutlined";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import { useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import { useCookies } from "react-cookie";

function Copyright(props) {
  return (
    <Typography
      variant="body2"
      color="text.secondary"
      align="center"
      {...props}
    >
      {"Copyright © "}
      <Link color="inherit" href="https://mui.com/">
        Your Website
      </Link>{" "}
      {new Date().getFullYear()}
      {"."}
    </Typography>
  );
}
const theme = createTheme();

export default function SignIn() {
  // let token =
  //   "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEyMzQ1Njc4OTAxMjMiLCJyb2xlIjoidXNlciIsIm5iZiI6MTY5NDg1Nzk2NCwiZXhwIjoxNjk0ODY4NzY0LCJpYXQiOjE2OTQ4NTc5NjQsImlzcyI6IlRvRG9BcHAiLCJhdWQiOiJwdWJsaWMifQ.Pb4qPoPEi-oorwKGsT-QGNhfjBFhFVg-VAlgJz0Bq70";

  const handleSubmit = (event) => {
    event.preventDefault();
    const data = new FormData(event.currentTarget);
    console.log({
      id: data.get("id"),
      password: data.get("password"),
    });
  };
  let [id, setId] = useState("");
  let [password, setPassword] = useState("");
  let navigate = useNavigate();
  let [cookies, setCookie] = useCookies(["token"]);

  return (
    <ThemeProvider theme={theme}>
      <Container component="main" maxWidth="xs">
        <CssBaseline />
        <Box
          sx={{
            marginTop: 8,
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
          }}
        >
          <Avatar sx={{ m: 1, bgcolor: "secondary.main" }}>
            <LockOutlinedIcon />
          </Avatar>
          <Typography component="h1" variant="h5">
            Sign in
          </Typography>
          <Box
            component="form"
            onSubmit={handleSubmit}
            noValidate
            sx={{ mt: 1 }}
          >
            <TextField
              margin="normal"
              required
              fullWidth
              id="id"
              label="Id"
              name="id"
              autoComplete="id"
              autoFocus
              value={id}
              onChange={(event) => setId(event.target.value)}
            />
            <TextField
              margin="normal"
              required
              fullWidth
              name="password"
              label="Password"
              type="password"
              id="password"
              autoComplete="current-password"
              value={password}
              onChange={(event) => setPassword(event.target.value)}
            />
            <FormControlLabel
              control={<Checkbox value="remember" color="primary" />}
              label="Remember me"
            />
            <Button
              type="submit"
              fullWidth
              variant="contained"
              sx={{ mt: 3, mb: 2 }}
              onClick={() => {
                axios
                  .post(
                    "http://localhost:3000/tokens",
                    { id: id, password: password },
                    {
                      headers: {
                        Authorization:
                          "Bearer " + JSON.parse(localStorage.getItem("token")),
                      },
                      timeout: 10 * 1000,
                    }
                  )
                  .then((response) => {
                    setCookie("token", response.data.token);
                    navigate("/main");
                  })
                  .catch((error) => {
                    if (error.code === "ECONNABORTED") {
                      console.log("timeout");
                    } else {
                      console.log(error.response.status);
                    }
                  });
              }}
              // onClick={() => navigate("/main")}
            >
              Sign In
            </Button>
            <Grid container>
              <Grid item xs>
                <Link href="#" variant="body2">
                  Forgot password?
                </Link>
              </Grid>
              <Grid item>
                <Link href="#" variant="body2">
                  {"Don't have an account? Sign Up"}
                </Link>
              </Grid>
            </Grid>
          </Box>
        </Box>
        <Copyright sx={{ mt: 8, mb: 4 }} />
      </Container>
    </ThemeProvider>
  );
}
