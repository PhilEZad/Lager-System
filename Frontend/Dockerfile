# Stage 1
FROM node:latest as node
WORKDIR /app
COPY . .
RUN npm install
RUN npm run build --prod

# Stage 2: Serve app with Nginx
FROM nginx:alpine
COPY nginx.conf /etc/nginx/nginx.conf
COPY --from=node /app/dist/frontend /usr/share/nginx/html
EXPOSE 80
ENV BACKEND_API_URL=http://backend-api:56277