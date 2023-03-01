pipeline {
    agent any
    triggers {
        pollSCM('1 * * * *')
        //cron('10 * * * *')
    }
    stages {
        stage('Build_backend') {
            steps {
                sh 'dotnet restore Backend/API/API.csproj'
                sh 'dotnet build Backend/API/API.csproj'
                echo 'build complete'
            }
        }
        stage('Build_frontend') {
             steps {
                 sh 'npm install --prefix ./Frontend'
                 sh 'ng lint ./Frontend/angular.json'
                 sh 'npm run build --prefix ./Frontend'
                 echo 'build complete'
             }
       }
        stage('Test') {
            steps {
                //
                echo 'test'
            }
        }
        stage('Deploy') {
            steps {
                //
                echo 'deploy'
            }
        }
    }
}