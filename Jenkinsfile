pipeline {
    agent any
    stages {
        stage('Build') {
            steps {
                sh 'dotnet restore Backend/API/API.csproj'
                sh 'dotnet build Backend/API/API.csproj'
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